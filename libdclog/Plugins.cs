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
  public class Plugins
  {
    private List<string> pluginpaths = new List<string>();
    private List<IPlugin> loadedplugins = new List<IPlugin>();
    private List<IPlugin> availableplugins = new List<IPlugin>();
    private List<Assembly> assemblies = new List<Assembly>();
    private List<string> blacklist = new List<string>();

    public delegate void AssemblyLoadedDelegate(Plugins who, Assembly assembly);
    public delegate void PluginLoadedDelegate(Plugins who, IPlugin plugin);

    public event AssemblyLoadedDelegate AssemblyLoaded;
    public event PluginLoadedDelegate PluginLoaded;

    public Plugins()
    {
      pluginpaths.Add(Application.StartupPath + @"\plugins\");
    }

    public List<string> PluginPaths { get { return pluginpaths; } }
    public List<IPlugin> LoadedPlugins { get { return loadedplugins; } }
    public List<IPlugin> AvailablePlugins { get { return availableplugins; } }
    public List<string> BlackList { get { return blacklist; } set { blacklist = value; } }

    public void Initialise(DDO instance)
    {
      foreach (IPlugin p in loadedplugins)
      {
        p.Initialise(instance);
      }
    }

    public void Unload()
    {
      foreach (IPlugin p in loadedplugins)
      {
        p.Destroy();
      }
      loadedplugins.Clear();
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
                    if (!blacklist.Contains(plugin.Name))
                    {
                      Helper.RaiseEventOnUIThread(PluginLoaded, new object[] { this, plugin });
                      loadedplugins.Add(plugin);                      
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
