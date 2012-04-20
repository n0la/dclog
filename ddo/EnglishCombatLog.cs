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
using System.Text.RegularExpressions;

namespace LibDDO.Combat
{
  public class EnglishCombatLog : ILanguageParser
  {
    private static Regex damagedone = new Regex(@"You hit (.*?) for (\d+) point[s]{0,1} of (.*?)damage\.", RegexOptions.Compiled);
    private static Regex damagedonedr = new Regex(@"You hit (.*?) for (\d+) point[s]{0,1} of (.*?) damage after (\d+) .*?blocked by (.*?)damage reduction\.", RegexOptions.Compiled);
    private static Regex killed = new Regex(@"You killed (.*?)\.", RegexOptions.Compiled);
    private static Regex damagervd = new Regex(@"(.*?) hit you for a total of (\d+) point[s]{0,1} of (.*?)damage\.", RegexOptions.Compiled);
    private static Regex damagervddr = new Regex(@"(.*?) hit you for a total of (\d+) point[s]{0,1} of (.*?)damage after (\d+) .*?blocked by (.*?)damage reduction\.", RegexOptions.Compiled);
    private static Regex damageno = new Regex(@"(.*?) hit you but did no damage\; (\d+) point[s]{0,1} of damage were blocked by (.*?)\.", RegexOptions.Compiled);
    private static Regex damage = new Regex(@"(.*?) hit you for (\d+) point[s]{0,1} of (.*?) damage\.", RegexOptions.Compiled);

    public DamageType StringToType(string t)
    {
      t = t.ToLower();
      switch (t)
      {
        case "slash": return DamageType.Slashing;
        case "bludgeon": return DamageType.Bludgeoning;
        case "pierce": return DamageType.Piercing;
        case "acid": return DamageType.Acid;
        case "good": return DamageType.Good;
        case "shock": return DamageType.Shock;
        case "fire": return DamageType.Fire;
        case "cold": return DamageType.Cold;
        case "chaotic": return DamageType.Chaotic;
        case "sonic": return DamageType.Sonic;
        case "force": return DamageType.Force;
        case "evil": return DamageType.Evil;
        case "lawful": return DamageType.Lawful;
        // Default: Unknown
        default: return DamageType.Unknown;
      }
    }

    public string TypeToString(DamageType t)
    {
      switch (t)
      {
        case DamageType.Acid: return "acid";
        case DamageType.Bludgeoning: return "bludgeon";
        case DamageType.Chaotic: return "chaotic";
        case DamageType.Cold: return "cold";
        case DamageType.Evil: return "evil";
        case DamageType.Fire: return "fire";
        case DamageType.Force: return "force";
        case DamageType.Good: return "good";
        case DamageType.Lawful: return "lawful";
        case DamageType.Piercing: return "pierce";
        case DamageType.Shock: return "shock";
        case DamageType.Slashing: return "slash";
        case DamageType.Sonic: return "sonic";        
        case DamageType.Unknown: return "unknown";
        default: return "unknown";
      }
    }

    private void ParseDamageDone(CombatLogMessage msg, Match m)
    {
      msg.Type = CombatLogType.DamageDone;
      string target = m.Groups[1].Value;
      uint points = 0;

      if (!UInt32.TryParse(m.Groups[2].Value, out points))
      {
        points = 0;
        msg.State = CombatLogMessageState.ParsingError;
        return;
      }

      string type = m.Groups[3].Value.Trim();
      uint blocked = 0;
      string blockedby = "";

      if (m.Groups.Count > 4) {
        if (!UInt32.TryParse(m.Groups[4].Value, out blocked))
        {
          blocked = 0;
          msg.State = CombatLogMessageState.ParsingError;
          return;
        }
        blockedby = m.Groups[5].Value.Trim();
      }

      msg.State = CombatLogMessageState.Parsed;
      msg.Damage = new Damage(points, blocked, blockedby, Damage.Player, target, StringToType(type));
      SplitTargetAbility(msg.Damage);
    }

    /// <summary>
    /// Parses no damage combat logs in form of
    /// "XXX hit you but did no damage; Y points of damage were blocked by damage reduction."
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="m"></param>
    private void ParseNoDamage(CombatLogMessage msg, Match m)
    {
      msg.Type = CombatLogType.DamageTaken;
      string source = m.Groups[1].Value;
      uint blocked = 0;
      if (!UInt32.TryParse(m.Groups[2].Value, out blocked))
      {
        blocked = 0;
        msg.State = CombatLogMessageState.ParsingError;
        return;
      }
      string blockedby = m.Groups[3].Value;

      msg.State = CombatLogMessageState.Parsed;
      msg.Damage = new Damage(0, blocked, blockedby, source, Damage.Player, DamageType.Unknown);
    }

    private void ParseDamageReceived(CombatLogMessage msg, Match m)
    {
      msg.Type = CombatLogType.DamageTaken;
      string source = m.Groups[1].Value;
      uint points = 0;

      if (!UInt32.TryParse(m.Groups[2].Value, out points))
      {
        points = 0;
        msg.State = CombatLogMessageState.ParsingError;
        return;
      }
      string type = m.Groups[3].Value.Trim();
      uint blocked = 0;
      string blockedby = "";

      if (m.Groups.Count > 4)
      {
        if (!UInt32.TryParse(m.Groups[4].Value, out blocked))
        {
          blocked = 0;
          msg.State = CombatLogMessageState.ParsingError;
          return;
        }
        blockedby = m.Groups[5].Value.Trim();
      }

      msg.State = CombatLogMessageState.Parsed;
      msg.Damage = new Damage(points, blocked, blockedby, source, Damage.Player, StringToType(type));
      SplitTargetAbility(msg.Damage);
    }

    public bool Parse(CombatLogMessage msg)
    {
      Match m = null;
      bool recognised = true;

      if ( (m = damagedone.Match(msg.Message)).Success ) 
      {
        ParseDamageDone(msg, m);
      } 
      else if ( (m = damagedonedr.Match(msg.Message)).Success ) 
      {
        ParseDamageDone(msg, m);
      }
      else if ((m = damagervd.Match(msg.Message)).Success)
      {
        ParseDamageReceived(msg, m);
      }
      else if ((m = damagervddr.Match(msg.Message)).Success)
      {
        ParseDamageReceived(msg, m);
      }
      else if ((m = damage.Match(msg.Message)).Success)
      {
        ParseDamageReceived(msg, m);
      }
      else if ((m = damageno.Match(msg.Message)).Success)
      {
        ParseNoDamage(msg, m);
      }
      else if ((m = killed.Match(msg.Message)).Success)
      {
        msg.Type = CombatLogType.TargetKilled;
        msg.Target = m.Groups[1].Value;
        msg.State = CombatLogMessageState.Parsed;
      }
      return recognised;
    }


    public bool SplitTargetAbility(Damage damage)
    {
      bool result = false;
      int idx = 0;
      string target, targetability;
      string source, sourceability;
      
      if ( (idx = damage.Target.IndexOf("'s")) != -1 ) {
        target = damage.Target.Substring(0, idx);
        targetability = damage.Target.Substring(idx + 2).Trim();
        if (target != "")
        {
          damage.Target = target;
        }
        if (targetability != "")
        {
          damage.TargetAbility = target;
        }
        result = true;
      }

      if ((idx = damage.Source.IndexOf("'s")) != -1)
      {
        source = damage.Source.Substring(0, idx);
        sourceability = damage.Source.Substring(idx + 2).Trim();
        if (source != "")
        {
          damage.Source = source;
        }
        if (sourceability != "")
        {
          damage.SourceAbility = sourceability;
        }
        result = true;
      }

      return result;
    }
  }
}
