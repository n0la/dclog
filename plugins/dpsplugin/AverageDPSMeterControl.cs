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
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using LibDDO;
using LibDDO.Combat;
using LibDDO.Combat.DPS;

namespace DCLog.DPSPlugin
{
  public partial class AverageDPSMeterControl : UserControl
  {
    private AverageTargetMeter singletarget = new AverageTargetMeter();
    private DDO instance = null;

    public AverageDPSMeterControl()
    {
      InitializeComponent();
    }

    public AverageDPSMeterControl(DDO instance)
    {
      this.instance = instance;
      this.instance.RegisterListener(singletarget);
      InitializeComponent();
      singletarget.Ticked += new DPSMeterTickedDelegate(singletarget_Ticked);
      singletarget.StateChanged += new DPSMeterStateChangedDelegate(singletarget_StateChanged);
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

    void singletarget_Ticked(DelayedTimedMeter meter)
    {
      // Add a point.
      int i = dpschart.Series[0].Points.AddXY(singletarget.TimePassed.TotalSeconds, singletarget.Result);
      dpschart.Series[0].Points[i].ToolTip = string.Format("{0} DPS", singletarget.Result);
    }

    private void ststart_Click(object sender, EventArgs e)
    {
      string target = "";

      if (!String.IsNullOrEmpty(sttarget.Text))
      {
        target = sttarget.Text;
      }

      singletarget.Stop();
      singletarget.Target = target;
      singletarget.Start();
      dpschart.Series[0].Points.Clear();
    }

    private void ststop_Click(object sender, EventArgs e)
    {
      singletarget.Stop();
    }

    private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
    {

    }
  }
}
