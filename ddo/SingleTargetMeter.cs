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
    
    public override void TargetKilled(CombatLogMessage msg)
    {
      if (State == MeterState.Stopped)
      {
        return;
      }

      // Stop if our target was killed.
      if (String.Compare(msg.Target, target, true) == 0)
      {
        Stop();
      }
    }

    public override void DamageDone(CombatLogMessage msg)
    {
      if (State == MeterState.Stopped)
      {
        return;
      }

      if (String.Compare(msg.Damage.Target, target, true) == 0)
      {
        damagedone += msg.Damage.EffectiveDamage;
        if (State != MeterState.Running)
        { // change state to running since we hit our target
          State = MeterState.Running;
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
