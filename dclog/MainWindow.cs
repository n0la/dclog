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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using LibDDO;
using LibDDO.Combat;
using LibDDO.Combat.DPS;
using LibDDO.Combat.Tanking;
using DCLog.Plugins;

namespace dclog
{
  public partial class MainWindow : Form
  {
    private Logger mainlogger = new Logger();
    private Plugins plugins = new Plugins();

    public MainWindow()
    {
      InitializeComponent();
      mainlogger.EnableAll();
      mainlogger.OnNewLog += new Logger.DOnNewLog(mainlogger_OnNewLog);
      DDO.Instance.OnNotify += new DDO.DDONotifyDelegate(Instance_OnNotify);
      DDO.Instance.OnChatMessage += new DDO.DDOOnChatMessage(Instance_OnChatMessage);
      plugins.PluginLoaded += new Plugins.PluginLoadedDelegate(plugins_PluginLoaded);
      plugins.AssemblyLoaded += new Plugins.AssemblyLoadedDelegate(plugins_AssemblyLoaded);
      plugins.PluginIncompatible += new Plugins.PluginIncompatibleDelegate(plugins_PluginIncompatible);
    }

    void plugins_PluginIncompatible(Plugins sender, IPlugin plugin)
    {
      mainlogger.Error(string.Format("Plugin {0} is incompatible with the current interface version {1}",
        plugin.Name,
        Plugins.InterfaceVersion.ToString()
        ));
    }

    void plugins_AssemblyLoaded(Plugins who, System.Reflection.Assembly assembly)
    {
      mainlogger.Info(string.Format("Assembly loaded: {0}, trusted: {1}, version: {2}",
        assembly.FullName,
        (assembly.IsFullyTrusted ? "Yes" : "No"),
        assembly.ImageRuntimeVersion.ToString()
        ));
    }

    void plugins_PluginLoaded(Plugins who, IPlugin plugin)
    {
      mainlogger.Info(string.Format("Plugin loaded: {0}, version: {1}",
        plugin.Name,
        plugin.Version.ToString()
        ));
    }

    private void attach_Click(object sender, EventArgs e)
    {
      try
      {
        int pid = 0;
        WaitBox box = new WaitBox();
        string msg = "Waiting for DDO to start...";

        mainlogger.Info(msg);
        box.InfoText = msg;

        box.Show(this);
        box.Refresh();

        while (pid == 0)
        {
          if (box.DialogResult == DialogResult.Cancel)
          {
            pid = 0;
            mainlogger.Error("User said we should no longer wait for DDO.");
            break;
          }

          Process[] res = Process.GetProcessesByName("dndclient");

          if (res.Length == 0)
          {
            Application.DoEvents();
          }
          else
          {
            if (res.Length > 1)
            {
              mainlogger.Warning("Multiboxing is currently not supporting, it is undefined which instance will be taken.");
            }
            pid = res[0].Id;
          }
        }
        if ( pid != 0 ) {
          box.Close();
          mainlogger.Info(String.Format("Appending to PID {0}", pid));
          DDO.Instance.HookOnto(pid);
        }
      }
      catch (Exception ex)
      {
        mainlogger.Error(ex.ToString());
      }
    }

    private void MainWindow_Load(object sender, EventArgs e)
    {
      try
      {
        // Apply black list from configuration.
        plugins.BlackList = Configuration.Instance.PluginBlackList;
        plugins.Load();
        plugins.Initialise(DDO.Instance);
        InitialisePlugins();
      }
      catch (Exception ex)
      {
        mainlogger.Error(ex.ToString());
      }
    }

    private void InitialisePlugins()
    {
      foreach (IPlugin p in plugins.LoadedPlugins)
      {
        List<Control> cs = p.Controls;
        foreach (Control c in cs)
        {
          TabPage pg = new TabPage(p.Name);
          c.Dock = DockStyle.Fill;
          pg.Controls.Add(c);
          maintabs.TabPages.Add(pg);
        }
      }
    }

    void Instance_OnChatMessage(DDO sender, ChatMessage message)
    {
      StringBuilder msg = new StringBuilder();

      msg.Append(message.ToString());
      msg.Append("\r\n");
      combatlog.AppendText(msg.ToString());
    }

    void Instance_OnNotify(DDO sender, string message)
    {
      mainlogger.Info(message);
    }

    void mainlogger_OnNewLog(Logger sender, string message)
    {
      applog.AppendText(message + "\r\n");
    }

    private void combatlog_TextChanged(object sender, EventArgs e)
    {
      combatlog.SelectionStart = combatlog.Text.Length;
      combatlog.ScrollToCaret();
      //combatlog.Refresh();
    }

    private void applog_TextChanged(object sender, EventArgs e)
    {
      applog.SelectionStart = applog.Text.Length;
      applog.ScrollToCaret();
      //applog.Refresh();
    }

    private void quitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
      Application.Exit();
    }

    private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string url = "https://github.com/n0la/dclog/issues";
      System.Diagnostics.Process.Start(url);
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutDialog dlg = new AboutDialog();
      dlg.ShowDialog(this);
    }

    private void feedFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        OpenFileDialog dlg = new OpenFileDialog();

        dlg.Title = "Open combat log file...";
        dlg.CheckFileExists = dlg.CheckPathExists = true;
        dlg.Filter = "All files *.*|*.*";

        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
          FileStream stream = new FileStream(dlg.FileNames[0], FileMode.Open);
          StreamReader reader = new StreamReader(stream);

          while (!reader.EndOfStream)
          {
            string line = reader.ReadLine();
            if (line.Length > 0)
            { // Add line to combat log
              DDO.Instance.AddMessage(line);
            }
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(this,
                        "Error occured while reading text file: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
      }
    }

    private void feedTextToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FeedDialog dlg = new FeedDialog();

      dlg.ShowDialog(this);
      if (dlg.DialogResult == DialogResult.OK)
      {
        // Add lines to combat log
        foreach (string s in dlg.Lines)
        {
          DDO.Instance.AddMessage(s);
        }
      }
    }

    private void pluginsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      PluginManager mgr = new PluginManager(plugins);

      mgr.ShowDialog();
    }
  }
}
