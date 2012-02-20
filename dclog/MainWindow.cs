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
using System.Linq;
using System.Text;
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
      DDO.Instance.RegisterListener(singletarget);
      singletarget.Ticked += new DPSMeterTickedDelegate(singletarget_Ticked);
      singletarget.StateChanged += new DPSMeterStateChangedDelegate(singletarget_StateChanged);

      DDO.Instance.RegisterListener(stm);
      DDO.Instance.RegisterListener(tmb);
      DDO.Instance.RegisterListener(tmt);
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
    }

    private void RefreshByMonster()
    {
      Series cur = tankchart.Series[0];

      cur.Points.Clear();

      foreach (var p in tmb.DamageValues)
      {
        cur.Points.Add(CreateNamedPoint(p.Key, p.Value.Points));
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
    }

    private void tankrefresh_Click(object sender, EventArgs e)
    {
      if (tankmeter.SelectedIndices.Count == 0)
      {
        return;
      }
      int selected = tankmeter.SelectedIndices[0];

      switch (selected)
      {
        case 0: RefreshSimple(); break;
        case 2: RefreshByMonster(); break;
        case 1: RefreshByType(); break;
      }

    }

    private void tanktimer_Tick(object sender, EventArgs e)
    {
      tankrefresh_Click(sender, e);
    }
  }
}
