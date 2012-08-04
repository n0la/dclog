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
using System.Timers;

namespace LibDDO.Combat.DPS
{
  public enum MeterState
  {
    Stopped = 0,
    Waiting,
    Running,
  }

  public delegate void DPSMeterTickedDelegate(DelayedTimedMeter meter);
  public delegate void DPSMeterStateChangedDelegate(DelayedTimedMeter meter, MeterState ny);

  /// <summary>
  /// This base class implements a DPS meter that calculates DPS over time at specific intervals. 
  /// Once the timer is started, calculation is delayed until the base class specifically starts the
  /// the calculation by setting its state from Waiting to Running. This allows to wait for a specific
  /// message before starting the calculation (i.e. wait until the target is first hit before starting
  /// the measurement).
  /// </summary>
  public class DelayedTimedMeter : IDPSMeter
  {
    public event DPSMeterTickedDelegate Ticked;
    public event DPSMeterStateChangedDelegate StateChanged;

    protected Timer timer = new Timer();
    protected MeterState state = MeterState.Stopped;
    protected uint passed = 0;

    protected MeterState State
    {
      get { return state; }
      set
      {
        state = value;
        Helper.RaiseEventOnUIThread(StateChanged, new object[] { this, value});
      }
    }

    public DelayedTimedMeter()
    {
      timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
      timer.Interval = 1000.0;
    }

    protected virtual void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
      if (state == MeterState.Running)
      {
        ++passed;
        Helper.RaiseEventOnUIThread(Ticked, new object[] { this });
      }
    }

    /// <summary>
    /// This should be overriden by a base class.
    /// </summary>
    /// <param name="msg"></param>
    public virtual void OnChatMessage(ChatMessage msg)
    {
    }

    /// <summary>
    /// This should be overriden by a base class, and must return the result
    /// at the time of calling.
    /// </summary>
    public virtual double Result { get { return 0.0; } }

    public virtual void Start()
    {
      timer.Stop();
      passed = 0;
      State = MeterState.Waiting;
      timer.Start();
    }

    public virtual void Stop()
    {
      timer.Stop();
      State = MeterState.Stopped;
    }

    public uint SecondsPassed
    {
      get { return passed; }
    }

    public virtual TimeSpan TimePassed
    {
      get
      {
        return TimeSpan.FromSeconds(passed);
      }
    }
  }
}
