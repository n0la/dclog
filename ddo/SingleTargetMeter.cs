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
using System.Linq;
using System.Text;
using System.Timers;

namespace LibDDO.Combat.DPS
{
  /// <summary>
  /// A simple, timed single target DPS meter.
  /// </summary>
  public class SingleTargetMeter : DelayedTimedMeter
  {
    private string target = "";
    private uint damagedone = 0;

    public SingleTargetMeter()
    {
    }

    public SingleTargetMeter(string target)
    {
      this.target = target;
    }

    public string Target
    {
      get { return target; }
      set { target = value; }
    }

    public override void Start()
    {
      base.Start();
      damagedone = 0;
    }

    public override void OnCombatLog(CombatLogMessage msg)
    {
      if (State == MeterState.Stopped)
      {
        return;
      }

      if (msg.Type == CombatLogType.DamageDone)
      {

        if (String.Compare(msg.Damage.Target, target, true) == 0)
        {
          damagedone += msg.Damage.Points;
          if (State != MeterState.Running)
          { // change state to running since we hit our target
            State = MeterState.Running;
          }
        }
      }
      else if (msg.Type == CombatLogType.TargetKilled)
      {
        // Stop if our target was killed.
        if (String.Compare(msg.Target, target, true) == 0)
        {
          Stop();
        }
      }
    }

    public override double Result
    {
      get {
        if (damagedone == 0 || SecondsPassed == 0)
        {
          return 0.0;
        }
        return (damagedone / SecondsPassed); 
      }
    }
  }
}
