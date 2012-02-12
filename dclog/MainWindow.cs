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
using LibDDO;
using LibDDO.Combat;
using LibDDO.Combat.DPS;

namespace dclog
{
  public partial class MainWindow : Form
  {
    private Logger mainlogger = new Logger();
    private SingleTargetMeter singletarget = new SingleTargetMeter();

    public MainWindow()
    {
      InitializeComponent();
      mainlogger.EnableAll();
      mainlogger.OnNewLog += new Logger.DOnNewLog(mainlogger_OnNewLog);
      DDO.Instance.OnNotify += new DDO.DDONotifyDelegate(Instance_OnNotify);
      DDO.Instance.OnCombatLogMessage += new DDO.DDOOnCombatLogMessageDelegate(Instance_OnCombatLogMessage);
      DDO.Instance.RegisterDPSMeter(singletarget);
      singletarget.Ticked += new DPSMeterTickedDelegate(singletarget_Ticked);
      singletarget.StateChanged += new DPSMeterStateChangedDelegate(singletarget_StateChanged);
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
      combatlog.AppendText(message.ToString() + "\r\n");
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
      combatlog.Refresh();
    }

    private void applog_TextChanged(object sender, EventArgs e)
    {
      applog.SelectionStart = applog.Text.Length;
      applog.ScrollToCaret();
      applog.Refresh();
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
  }
}
