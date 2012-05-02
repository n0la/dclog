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

namespace LibDDO.Combat
{
  /// <summary>
  /// Interface for parsers that parse a log string of the game into Messages.
  /// </summary>
  public interface ILanguageParser
  {
    /// <summary>
    /// Parse the given combat log message and fill the structure.
    /// </summary>
    /// <param name="msg">Message to parse.</param>
    /// <returns>If the message was successfuly parsed or not.</returns>
    bool Parse(CombatLogMessage msg);

    /// <summary>
    /// Convert the given language string to a damage type. String should is as it appears
    /// in the combat log.
    /// </summary>
    /// <param name="t">String denoting a damage type.</param>
    /// <returns></returns>
    DamageType StringToType(string t);

    /// <summary>
    /// Convert the given damage type to the string representing it. String should be as it
    /// appears in the combat log.
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    string TypeToString(DamageType t);

    /// <summary>
    /// Given a string denoting a target (either a mob or the player), split the ability used
    /// from the user of the ability. Example:
    ///  input = Troll Shaman's inflict serious wounds
    /// End result:
    ///  return = true
    ///  damage.{Target,Source} = Troll Shaman
    ///  damage.{TargetAbility,SourceAbility} = inflict serious wounds
    /// </summary>
    /// <param name="damage"></param>
    /// <returns></returns>
    bool SplitTargetAbility(Damage damage);
  }
}
