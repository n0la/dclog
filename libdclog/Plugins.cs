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
    private List<IPlugin> plugins = new List<IPlugin>();
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
    public List<IPlugin> LoadedPlugins { get { return plugins; } }
    public List<string> BlackList { get { return blacklist; } }

    public void Initialise(DDO instance)
    {
      foreach (IPlugin p in plugins)
      {
        p.Initialise(instance);
      }
    }

    public void Unload()
    {
      foreach (IPlugin p in plugins)
      {
        p.Destroy();
      }
      plugins.Clear();
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
                assemblies.Add(assembly);

                Type[] types = assembly.GetTypes();
                foreach (Type t in types)
                {
                  if (t.GetInterface("IPlugin") != null)
                  {
                    IPlugin plugin = Activator.CreateInstance(t) as IPlugin;
                    if (!blacklist.Contains(plugin.Name))
                    {
                      Helper.RaiseEventOnUIThread(PluginLoaded, new object[] { this, plugin });
                      plugins.Add(plugin);
                    }
                  }
                } // foreach
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
