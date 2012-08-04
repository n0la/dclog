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
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace dclog
{
  /**
   * Class for internal configuration value storage. Not be used directly.
   * Use the singleton Configuration instead.
   */
  [Serializable]
  public class CfgContainer
  {
    private string logdirectory = "";
    private List<String> pluginblacklist = new List<string>();
    private Configuration c;

    public CfgContainer()
    {
    }

    private string GetDefault(string variable, string def) 
    {
      if (string.IsNullOrEmpty(variable))
      {
        return def;
      }
      return variable;
    }

    [XmlIgnore]
    public Configuration Configuration
    {
      get { return c; }
      set 
      { 
        c = value;
      }
    }

    public string LogDirectory
    {
      get { return GetDefault(logdirectory, (c.ConfigPath + @"\logs")); }
      set { logdirectory = value; }
    }

    public List<string> PluginBlackList
    {
      get { return pluginblacklist; }
      set { pluginblacklist = value; }
    }
  }

  public class Configuration
  {
    string configpath;
    string configfile;
    private CfgContainer container = new CfgContainer();
    static Configuration instance = null;

    #region Initialise and save/load stuff
    private Configuration()
    {
      configpath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      configpath = configpath + @"\dclog";
      if (!Directory.Exists(configpath)) 
      {
        Directory.CreateDirectory(configpath);
      }
      configfile = configpath + @"\dclog.config";
      container.Configuration = this;
    }

    public static Configuration Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new Configuration();
        }
        return instance;
      }
    }

    public void Load()
    {
      if (!File.Exists(configfile))
      { // File not found, not a tragic error.
        return;
      }

      CfgContainer container = null;
      XmlSerializer serializer = new XmlSerializer(typeof(CfgContainer));
      FileStream stream = new FileStream(configfile, FileMode.Open);

      try
      {
        container = serializer.Deserialize(stream) as CfgContainer;
        stream.Close();
        if (container == null)
        {
          throw new ApplicationException("Invalid configuration file.");
        }        
        container.Configuration = this;
        this.container = container;
      }
      catch (Exception ex)
      {
        stream.Close();
        throw ex; // rethrow
      }
    }

    public void Save()
    {
      XmlSerializer serializer = new XmlSerializer(typeof(CfgContainer));
      FileStream stream = new FileStream(configfile, FileMode.Create);

      try
      {
        serializer.Serialize(stream, container);
        stream.Close();
      }
      catch (Exception ex)
      {
        stream.Close();
        throw ex;
      }
    }
    #endregion

    public string ConfigPath
    {
      get { return configpath; }
    }

    public string ConfigFile
    {
      get { return configfile; }
    }

    public List<string> PluginBlackList
    {
      get { return container.PluginBlackList; }
    }

    public string LogDirectory
    {
      get { return container.LogDirectory; }
      set { container.LogDirectory = value; }
    }
  }
}
