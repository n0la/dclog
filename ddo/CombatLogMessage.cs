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

  public enum CombatLogMessageState : int
  {
    /// <summary>
    /// The type is unknown.
    /// </summary>
    Unknown = 0,
    /// <summary>
    /// The message was successfully parsed.
    /// </summary>
    Parsed,
    /// <summary>
    /// The message was recognised, but failed to parse properly.
    /// </summary>
    ParsingError
  }

  /// <summary>
  /// A single message in the combat log. It can be parsed, if the respective parser has recognised
  /// the combat log message. Or unparsed and unknown.
  /// </summary>
  public class CombatLogMessage
  {
    private string message = "";
    private string target = "";
    private DateTime timestamp ;
    private StringBuilder b = new StringBuilder();
    private StringBuilder orig = new StringBuilder();
    private CombatLogType type = CombatLogType.Unknown;
    private Damage damage = new Damage();
    private CombatLogMessageState state = CombatLogMessageState.Unknown;

    public CombatLogMessage(string msg)
    {
      message = msg;
      // Remove the (Combat) or whatever is in front of it.
      message = message.Remove(0, message.IndexOf(' ')+1);
      timestamp = DateTime.Now;
    }

    public CombatLogMessageState State
    {
      get { return state; }
      set { state = value; }
    }

    public CombatLogType Type
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

    public string Message
    {
      get { return message; }
    }

    public DateTime TimeStamp
    {
      get { return timestamp; }
    }

    /// <summary>
    /// Converts this combat log message to the original string as it appeared in the game.
    /// </summary>
    /// <returns>The games representation of the combat log message.</returns>
    public string ToOriginalString()
    {
      if (orig.Length == 0)
      {
        orig.Append("(Combat): ");
        orig.Append(message);
      }
      return orig.ToString();
    }

    /// <summary>
    /// Returns the combat log message with additional information, including whether the
    /// message was successfully parsed or not, and the timestamp when this message occured.
    /// </summary>
    /// <returns>String representation of the combat log message.</returns>
    public override string ToString()
    {
      if (b.Length == 0)
      {
        if (state == CombatLogMessageState.Unknown)
        {
          b.Append("[??] ");
        }
        else if (state == CombatLogMessageState.ParsingError)
        {
          b.Append("[EE] ");
        }
        else if (state == CombatLogMessageState.Parsed)
        {
          b.Append("[OK] ");
        }

        b.Append(timestamp.ToLongTimeString());
        b.Append("+");
        b.Append(timestamp.Millisecond);
        b.Append(": (Combat) ");
        b.Append(message);
      }

      return b.ToString();
    }
  }
}
