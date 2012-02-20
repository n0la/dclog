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

namespace LibDDO.Combat.Tanking
{
  public class SimpleTankMeter : ITankMeter
  {
    private uint damagetaken = 0;
    private uint damageblocked = 0;

    public void OnCombatLog(CombatLogMessage msg)
    {
      if (msg.Type == CombatLogType.DamageTaken)
      {
        damagetaken += msg.Damage.Points;
        damageblocked += msg.Damage.Blocked;
      }
    }

    public uint DamageTaken { get { return damagetaken; } }
    public uint DamageBlocked { get { return damageblocked; } }
  }
}
