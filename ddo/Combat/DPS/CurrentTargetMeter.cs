using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibDDO.Combat.DPS
{
  public delegate void CurrentDPSMeterTicked(CurrentTargetMeter meter, uint damage);

  /// <summary>
  /// Calculates the current DPS done, either overall or against a single target.
  /// </summary>
  public class CurrentTargetMeter : DelayedTimedTargetMeter
  {
    private uint damagedone = 0;

    public new event CurrentDPSMeterTicked Ticked;

    public CurrentTargetMeter()
    {
    }

    protected override void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
      if (State == MeterState.Running)
      { 
        ++passed;
        Helper.RaiseEventOnUIThread(Ticked, new object[] { this, damagedone });
        // Reset damage done every tick.
        damagedone = 0;
      }
    }

    public override void OnChatMessage(ChatMessage msg)
    {
      if (State == MeterState.Stopped)
      {
        return;
      }

      if (msg.IsCombat)
      {
        CombatMessage c = msg as CombatMessage;

        if (c.CombatType == CombatLogType.DamageDone)
        {

          if (String.Compare(c.Damage.Target, target, true) == 0 ||
              String.IsNullOrEmpty(target))
          {
            damagedone += c.Damage.Points;
            if (State != MeterState.Running)
            { // change state to running since we hit our target
              State = MeterState.Running;
            }
          }
        }
        else if (c.CombatType == CombatLogType.TargetKilled)
        {
          // Stop if our target was killed.
          if (String.Compare(c.Target, target, true) == 0)
          {
            Stop();
          }
        }
      }
    }

    public override double Result
    {
      get
      {
        return (double)damagedone;
      }
    }
  }
}
