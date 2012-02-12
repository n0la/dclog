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
  public enum CombatLogType : int
  {
    Unknown = 0,
    DamageDone,
    DamageTaken,
    TargetKilled,
  }

  public class CombatLogMessage
  {
    private string message = "";
    private string target = "";
    private DateTime timestamp ;
    private StringBuilder b = new StringBuilder();
    private CombatLogType type = CombatLogType.Unknown;
    private Damage damage = new Damage();

    public CombatLogMessage(string msg)
    {
      message = msg;
      // Remove the (Combat) or whatever is in front of it.
      message = message.Remove(0, message.IndexOf(' ')+1);
      timestamp = DateTime.Now;
    }

    public CombatLogType Type
    {
      get { return type; }
      set { type = value; }
    }

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

    public override string ToString()
    {
      if (b.Length == 0)
      {
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
