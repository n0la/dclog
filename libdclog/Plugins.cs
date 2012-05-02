/*
 * DCLog ~ A DDO Combat Logger
 * Copyright (C) 2012 Florian Stinglmayr
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using LibDDO;

namespace DCLog.Plugins
{
  /// <summary>
  /// Dynamically manages plugins to DCLog.
  /// </summary>
  public class Plugins
  {
    public static Version InterfaceVersion = new Version(1, 0, 0);

    private List<string> pluginpaths = new List<string>();
    private List<IPlugin> loadedplugins = new List<IPlugin>();
    private List<IPlugin> availableplugins = new List<IPlugin>();
    private List<Assembly> assemblies = new List<Assembly>();
    private List<string> blacklist = new List<string>();
    private Version version = Plugins.InterfaceVersion;

    public delegate void AssemblyLoadedDelegate(Plugins sender, Assembly assembly);
    public delegate void PluginLoadedDelegate(Plugins sender, IPlugin plugin);
    public delegate void PluginIncompatibleDelegate(Plugins sender, IPlugin plugin);

    /// <summary>
    /// Emitted when a new assembly (DLL file) is loaded into the address space.
    /// </summary>
    public event AssemblyLoadedDelegate AssemblyLoaded;

    /// <summary>
    /// Emitted when a plugin was successfully loaded.
    /// </summary>
    public event PluginLoadedDelegate PluginLoaded;

    /// <summary>
    /// Emitted when a module reported incompability with the host version.
    /// </summary>
    public event PluginIncompatibleDelegate PluginIncompatible;

    public Plugins()
    {
      pluginpaths.Add(Application.StartupPath + @"\plugins\");
    }

    /// <summary>
    /// A list of folders that should be searched when loading modules.
    /// </summary>
    public List<string> PluginPaths { get { return pluginpaths; } }

    /// <summary>
    /// A list of loaded modules, that are both compatible with the current version and
    /// are not black listed.
    /// </summary>
    public List<IPlugin> LoadedPlugins { get { return loadedplugins; } }

    /// <summary>
    /// A list of all available plugins, including black listed and incompatible plugins.
    /// </summary>
    public List<IPlugin> AvailablePlugins { get { return availableplugins; } }
    
    /// <summary>
    /// A list of names of modules that are not to be loaded.
    /// </summary>
    public List<string> BlackList 
    { 
      get { return blacklist; } 
      set { blacklist = value; } 
    }
    
    /// <summary>
    /// The version against which compability should be checked. Per default this value
    /// is the same as Plugins.InterfaceVersion.
    /// </summary>
    public Version HostVersion 
    { 
      get { return version; } 
      set { version = value; } 
    }

    /// <summary>
    /// Initialise all loaded plugins.
    /// </summary>
    /// <param name="instance">The DDO instance the plugins should base their work on.</param>
    public void Initialise(DDO instance)
    {
      foreach (IPlugin p in loadedplugins)
      {
        p.Initialise(instance);
      }
    }
    
    /// <summary>
    /// Unload all loaded plugins.
    /// </summary>
    public void Unload()
    {
      foreach (IPlugin p in loadedplugins)
      {
        p.Destroy();
      }
      loadedplugins.Clear();
      availableplugins.Clear();
      assemblies.Clear();
    }

    public void Load()
    {
      Unload();
      try
      {
        foreach (string p in pluginpaths)
        {
          List<string> files = new List<string>(Directory.EnumerateFiles(p, "*.dll"));
          if (files.Count > 0)
          {
            foreach (string f in files)
            {
              Assembly assembly = Assembly.LoadFile(f);
              if (assembly != null)
              {
                Helper.RaiseEventOnUIThread(AssemblyLoaded, new object[] { this, assembly });
                
                int count = 0;
                Type[] types = assembly.GetTypes();
                foreach (Type t in types)
                {
                  if (t.GetInterface("IPlugin") != null)
                  {
                    IPlugin plugin = Activator.CreateInstance(t) as IPlugin;
                    if (!plugin.IsCompatible(version))
                    { // Not compatible
                      Helper.RaiseEventOnUIThread(PluginIncompatible, new object[] { this, plugin });
                    }
                    else
                    {
                      if (!blacklist.Contains(plugin.Name))
                      {
                        Helper.RaiseEventOnUIThread(PluginLoaded, new object[] { this, plugin });
                        loadedplugins.Add(plugin);
                      }
                    }
                    availableplugins.Add(plugin);
                    ++count;
                  }
                } // foreach

                if (count > 0)
                { // Plugins loaded, store it!
                  assemblies.Add(assembly);
                }
              }
            } // foreach
          }
        } // foreach
      }
      catch (Exception)
      {
      }
    }


  }
}
