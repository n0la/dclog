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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LibDDO.Combat.DPS;

namespace DCLog.DPSPlugin
{
  public partial class CurrentDPSControl : UserControl
  {
    private LibDDO.DDO instance = null;
    private CurrentTargetMeter meter = new CurrentTargetMeter();

    public CurrentDPSControl()
    {
      InitializeComponent();
    }

    public CurrentDPSControl(LibDDO.DDO instance)
    {
      InitializeComponent();

      this.instance = instance;
      this.instance.RegisterListener(meter);
      meter.StateChanged += new DPSMeterStateChangedDelegate(meter_StateChanged);
      meter.Ticked += new CurrentDPSMeterTicked(meter_Ticked);
    }

    void meter_Ticked(CurrentTargetMeter meter, uint result)
    {
      // Add a point.
      dpschart.Series[0].Points.AddXY(meter.TimePassed.TotalSeconds, result);
    }

    void meter_StateChanged(DelayedTimedMeter meter, MeterState ny)
    {
      switch (ny)
      {
        case MeterState.Waiting: ststatus.Text = "Waiting..."; ststatus.ForeColor = Color.Orange; break;
        case MeterState.Stopped: ststatus.Text = "Stopped!"; ststatus.ForeColor = Color.Red; break;
        case MeterState.Running: ststatus.Text = "Running!"; ststatus.ForeColor = Color.Green; break;
      }
    }

    private void ststart_Click(object sender, EventArgs e)
    {
      string target = "";

      if (!String.IsNullOrEmpty(sttarget.Text))
      {
        target = sttarget.Text;
      }

      meter.Stop();
      meter.Target = target;
      meter.Start();
      dpschart.Series[0].Points.Clear();
    }

    private void ststop_Click(object sender, EventArgs e)
    {
      meter.Stop();
    }


  }
}
