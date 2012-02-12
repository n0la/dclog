using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LibDDO.Combat
{
  public class EnglishCombatLog : ILanguageParser
  {
    private static Regex damagedone = new Regex(@"You hit (.*?) for (\d+) point[s]{0,1} of (.*?)damage\.");
    private static Regex damagedonedr = new Regex(@"You hit (.*?) for (\d+) point[s]{0,1} of (.*?) damage after (\d+) were blocked by (.*?)damage reduction\.");
    private static Regex killed = new Regex(@"You killed (.*?)\.");

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
        // Default: Unknown
        default: return DamageType.Unknown;
      }
    }

    private void ParseDamageDone(CombatLogMessage msg, Match m)
    {
      msg.Type = CombatLogType.DamageDone;
      string target = m.Groups[1].Value;
      uint points = 0;

      UInt32.TryParse(m.Groups[2].Value, out points);

      string type = m.Groups[3].Value.Trim();
      uint blocked = 0;
      string blockedby = "";

      if (m.Groups.Count > 4) {
        UInt32.TryParse(m.Groups[4].Value, out blocked);
        blockedby = m.Groups[5].Value.Trim();
      }

      msg.Damage = new Damage(points, blocked, blockedby, Damage.Player, target, StringToType(type));      
    }

    public bool Parse(CombatLogMessage msg)
    {
      Match m = null;
      bool recognised = false;

      if ( (m = damagedone.Match(msg.Message)).Success ) 
      {
        ParseDamageDone(msg, m);
        recognised = true;
      } 
      else if ( (m = damagedonedr.Match(msg.Message)).Success ) 
      {
        ParseDamageDone(msg, m);
        recognised = true;
      } 
      else if ( (m = killed.Match(msg.Message)).Success ) 
      {
        msg.Type = CombatLogType.TargetKilled;
        msg.Target = m.Groups[1].Value;
      }
      return recognised;
    }
  }
}
