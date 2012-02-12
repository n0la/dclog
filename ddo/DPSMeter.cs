using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibDDO.Combat.DPS
{

  public interface IDPSMeter
  {
    void Start();
    void Stop();
    void DamageDone(CombatLogMessage msg);
    void TargetKilled(CombatLogMessage msg);
    double Result { get; }
    TimeSpan TimePassed { get; }
  }
}
