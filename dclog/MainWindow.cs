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

namespace dclog
{
  public partial class MainWindow : Form
  {
    private Logger mainlogger = new Logger();
    private SingleTargetMeter singletarget = new SingleTargetMeter();
    private SimpleTankMeter stm = new SimpleTankMeter();
    private TankMeterByMonster tmb = new TankMeterByMonster();
    private TankMeterByType tmt = new TankMeterByType();

    public MainWindow()
    {
      InitializeComponent();
      mainlogger.EnableAll();
      mainlogger.OnNewLog += new Logger.DOnNewLog(mainlogger_OnNewLog);
      DDO.Instance.OnNotify += new DDO.DDONotifyDelegate(Instance_OnNotify);
      DDO.Instance.OnCombatLogMessage += new DDO.DDOOnCombatLogMessageDelegate(Instance_OnCombatLogMessage);
      DDO.Instance.OnString += new DDO.DDOOnStringDelegate(Instance_OnString);
      DDO.Instance.RegisterListener(singletarget);
      singletarget.Ticked += new DPSMeterTickedDelegate(singletarget_Ticked);
      singletarget.StateChanged += new DPSMeterStateChangedDelegate(singletarget_StateChanged);

      DDO.Instance.RegisterListener(stm);
      DDO.Instance.RegisterListener(tmb);
      DDO.Instance.RegisterListener(tmt);
    }

    void Instance_OnString(DDO sender, string str)
    {
      addstrings.AppendText(str + "\r\n");
      addstrings.SelectionStart += str.Length;
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
    }

    void Instance_OnCombatLogMessage(DDO sender, CombatLogMessage message)
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

    private void ststart_Click(object sender, EventArgs e)
    {
      if (String.IsNullOrEmpty(sttarget.Text))
      {
        return;
      }

      singletarget.Stop();
      singletarget.Target = sttarget.Text;
      singletarget.Start();
      dpschart.Series[0].Points.Clear();
    }

    private void ststop_Click(object sender, EventArgs e)
    {
      singletarget.Stop();
    }

    void singletarget_Ticked(DelayedTimedMeter meter)
    {
      // Add a point.
      dpschart.Series[0].Points.AddXY(singletarget.TimePassed.TotalSeconds, singletarget.Result);
    }

    void singletarget_StateChanged(DelayedTimedMeter meter, MeterState ny)
    {
      switch (ny)
      {
        case MeterState.Waiting: ststatus.Text = "Waiting..."; ststatus.ForeColor = Color.Orange; break;
        case MeterState.Stopped: ststatus.Text = "Stopped!"; ststatus.ForeColor = Color.Red; break;
        case MeterState.Running: ststatus.Text = "Running!"; ststatus.ForeColor = Color.Green; break;
      }
    }

    private void tankmeter_SelectedIndexChanged(object sender, EventArgs e)
    {
      tankrefresh_Click(sender, e);
    }

    private DataPoint CreateNamedPoint(string name, double x, double y)
    {
      DataPoint pnt = new DataPoint(x, y);
      pnt.Label = name;

      return pnt;
    }

    private DataPoint CreateNamedPoint(string name, double value)
    {
      DataPoint pnt = new DataPoint(value, value);
      pnt.Label = value.ToString();
      pnt.ToolTip = pnt.LegendText = name + ": " + value.ToString();

      return pnt;
    }

    private void RefreshSimple()
    {
      Series cur = tankchart.Series[0];
      cur.Points.Clear();
      cur.Points.Add(CreateNamedPoint("Damage taken", stm.DamageTaken));
      cur.Points.Add(CreateNamedPoint("Damage blocked", stm.DamageBlocked));
      NoTotal();
    }

    public TreeNode FindByTag(TreeNode parent, string tag)
    {
      for ( int i = 0; i < parent.Nodes.Count; i++ ) 
      {
        TreeNode child = parent.Nodes[i];
        if ((child.Tag as string) == tag)
        {
          return child;
        }
      }
      return null;
    }

    private void AddMonsters()
    {
      var nodes = tankmeter.Nodes.Find("monster", false);

      if (nodes.Length == 1)
      {
        TreeNode node = nodes[0];
        // Add new child elements in case they are not there yet.
        foreach (var p in tmb.DamageValues)
        {
          var exists = node.Nodes.Find(p.Key, true);
          if (exists.Length == 0)
          {
            TreeNode ny = new TreeNode(p.Key);
            TreeNode byattack = new TreeNode("By ability");
            TreeNode blockratio = new TreeNode("Block ratio");

            ny.Tag = "monster";
            ny.Name = p.Key;

            byattack.Tag = "monster";
            byattack.Name = "byability";

            blockratio.Tag = "monster";
            blockratio.Name = "blockratio";

            ny.Nodes.Add(byattack);
            ny.Nodes.Add(blockratio);

            node.Nodes.Add(ny);
          }
        }
      }
    }

    private void RefreshByMonster()
    {
      TreeNode node = tankmeter.SelectedNode;

      if (node.Parent == null)
      { // Parent node selected, show a summary. The summary is provided by TankMeterByMonster
        Series cur = tankchart.Series[0];
        cur.Points.Clear();

        foreach (var p in tmb.Summary)
        {
          cur.Points.Add(CreateNamedPoint(p.Key, p.Value.Points));
        }
        AddTotal();
      }
      else if (node.Name == "byability")
      { // By ability has been selected, display damage by attacks done by the monster.
        Series cur = tankchart.Series[0];
        cur.Points.Clear();

        if (!tmb.DamageValues.ContainsKey(node.Parent.Text))
        { // Error
          return;
        }

        MonsterDamage dmg = tmb.DamageValues[node.Parent.Text];
        foreach (var p in dmg)
        {
          cur.Points.Add(CreateNamedPoint(p.Key, p.Value.Points));
        }
        AddTotal();
      }
      else if (node.Name == "blockratio")
      { // The taken/blocked ratio for that monster
        Series cur = tankchart.Series[0];
        cur.Points.Clear();

        if (!tmb.Summary.ContainsKey(node.Parent.Text))
        {
          return;
        }

        var summary = tmb.Summary[node.Parent.Text];
        cur.Points.Add(CreateNamedPoint("Damage taken", summary.Points));
        cur.Points.Add(CreateNamedPoint("Damage blocked", summary.Blocked));
        NoTotal();
      }
    }

    private void RefreshByType()
    {
      Series cur = tankchart.Series[0];

      cur.Points.Clear();

      foreach (var p in tmt.DamageValues)
      {
        cur.Points.Add(CreateNamedPoint(p.Key.ToString(), p.Value.Points));
      }
      AddTotal();      
    }

    private void NoTotal()
    {
      tankchart.Legends[0].CustomItems.Clear();
    }

    /// <summary>
    /// Add a "Total #value" as the last data point.
    /// </summary>
    /// <param name="points"></param>
    private void AddTotal()
    {
      double total = 0;

      foreach (var p in tankchart.Series[0].Points)
      {
        total += p.XValue;
      }

      LegendItem item = new LegendItem();
      item.Name = string.Format("Total: {0}", total);
      item.Color = Color.Pink;
      item.BorderWidth = 0;

      tankchart.Legends[0].CustomItems.Clear();
      tankchart.Legends[0].CustomItems.Add(item);
    }

    /**
     * Damage received            ~ Entire damage received, show blocked/received ratio
     * Damage received by type    ~ Entire damage received sorted by type
     * Damage received by monster ~ Show damage done by monsters, 
     *                              i.e. which monster has done the most damage?
     *  o Monster                 ~ TODO
     *    o By attack             ~ Show damage done by specific attack.
     *    o By type               ~ Show damage done by monster sorted by type. TODO
     *    
     * The three root nodes all have tags. The tags are:
     *  Damage received: simple
     *  Damage received by type: type
     *  Damage received by monster: monster
     * Child nodes of these should have the same tag for the trigger to work. Each update
     * method can use the Name property to differentiate the child nodes.
     * 
     * **TODO** Find better way for node handling.
     */
    private void tankrefresh_Click(object sender, EventArgs e)
    {
            // Make sure monsters are added as soon as possible.
      AddMonsters();

      if (tankmeter.SelectedNode == null)
      {
        return;
      }
      string selected = tankmeter.SelectedNode.Tag as string;

      switch (selected)
      {
        case "simple": RefreshSimple(); break;
        case "monster": RefreshByMonster(); break;
        case "type": RefreshByType(); break;
      }
    }

    private void tanktimer_Tick(object sender, EventArgs e)
    {
      tankrefresh_Click(sender, e);
    }

    private void quitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
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
              DDO.Instance.AddCombatLogMessage(line);
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
          DDO.Instance.AddCombatLogMessage(s);
        }
      }
    }
  }
}
