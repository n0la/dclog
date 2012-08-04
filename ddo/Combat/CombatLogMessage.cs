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
  /// The general type of the combat log.
  /// </summary>
  public enum CombatLogType : int
  {
    /// <summary>
    /// The type is unkown.
    /// </summary>
    Unknown = 0,
    /// <summary>
    /// The player has caused damage to a mob.
    /// </summary>
    DamageDone,
    /// <summary>
    /// A mob has caused damage to the player.
    /// </summary>
    DamageTaken,
    /// <summary>
    /// A mob has been killed.
    /// </summary>
    TargetKilled,
  }

  /// <summary>
  /// A single message in the combat log. It can be parsed, if the respective parser has recognised
  /// the combat log message. Or unparsed and unknown.
  /// </summary>
  public class CombatMessage : ChatMessage
  {
    private string target = "";
    private CombatLogType type = CombatLogType.Unknown;
    private Damage damage = new Damage();

    public CombatMessage(string type, string text) 
      : base(type, text)
    {      
    }

    public CombatMessage(ChatMessage msg)
      : base(msg)
    {
    }

    public CombatLogType CombatType
    {
      get { return type; }
      set { type = value; }
    }

    /// <summary>
    /// The actual damage inflicted or taken.
    /// </summary>
    public Damage Damage
    {
      get { return damage; }
      set 
      { 
        damage = value;
        if (value.Target != null &&
             value.Target.Length > 0)
        {
          target = value.Target;
        }
      }
    }

    /// <summary>
    /// The target of the combat log message. Either the monster you killed or damaged.
    /// </summary>
    public string Target
    {
      get { return target; }
      set { target = value; }
    }

    public override MessageType MessageType
    {
      get { return MessageType.Combat;  }
    }
  }
}
