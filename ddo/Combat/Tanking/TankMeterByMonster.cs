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
  public class MonsterDamage : Dictionary<string, Damage>
  {
    /// <summary>
    /// Creates an entry for the ability "ability" if it does not exist.
    /// </summary>
    /// <param name="ability"></param>
    public void Create(string ability)
    {
      if (!this.ContainsKey(ability))
      {
        this[ability] = new Damage();
      }
    }
  }

  /// <summary>
  /// Gives detailed information of damage received by monsters and their abilities (spells, special attacks, etc.).
  /// **TODO** The overall design of this tankmeter is lacking. It, for example, IS-A SimpleTankMeter per
  /// monster type. This should be fixed, and properly designed.
  /// </summary>
  public class TankMeterByMonster : ITankMeter
  {
    // While we can keep just one reference, and calculate ''summary'' out of ''dmg'', this saves
    // execution time. And at the time of writing, executing speed took precedence over memory used.
    private Dictionary<string, MonsterDamage> dmg = new Dictionary<string, MonsterDamage>();
    private Dictionary<string, Damage> summary = new Dictionary<string, Damage>();

    public void OnChatMessage(ChatMessage c)
    {
      if (c.IsCombat)
      {
        CombatMessage msg = c as CombatMessage;
        if (msg.CombatType == CombatLogType.DamageTaken)
        {
          string str = msg.Damage.Source;
          string ability = msg.Damage.SourceAbility;

          if (ability == "")
          { // **TODO** i18n required
            ability = "default";
          }

          if (!dmg.ContainsKey(str))
          { // add reference
            dmg[str] = new MonsterDamage();
          }
          if (!summary.ContainsKey(str))
          { // Add if it doesn't exist.
            summary[str] = new Damage();
          }

          dmg[str].Create(ability);
          dmg[str][ability] += msg.Damage;

          summary[str] += msg.Damage;
        }
      }
    }

    public Dictionary<string, MonsterDamage> DamageValues { get { return dmg; } }

    /// <summary>
    /// A cumulative summary of DamageValues provided for convinience.
    /// </summary>
    public Dictionary<string, Damage> Summary { get { return summary; } }
  }
}
