using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibDDO.Combat
{
  public enum DamageType : int
  {
    Unknown = 0,
    Slashing,
    Piercing,
    Bludgeoning,
    Acid,
    Fire,
    Good,
    Cold,
    Shock,
    Chaotic,
    Sonic
  }

  public class Damage
  {
    private uint points = 0;
    private uint blocked = 0;
    private string blockedby = "";
    private string source = "";
    private string target = "";
    private DamageType type = DamageType.Unknown;

    public static readonly string Player = "player";

    public Damage()
    {
    }

    public Damage(uint points, uint blocked, string blockedby, string source, string target, DamageType type)
    {
      this.points = points;
      this.blocked = blocked;
      this.blockedby = blockedby;
      this.source = source;
      this.target = target;
      this.type = type;
    }

    /// <summary>
    /// Effective damage done, i.e. Points - Blocked;
    /// </summary>
    public uint EffectiveDamage
    {
      get 
      {
        uint effective = points - blocked;
        return (effective >= 0 ? effective : 0);
      }
    }

    public uint Points
    {
      get { return points; }
    }

    public uint Blocked
    {
      get { return blocked; }
    }

    public string BlockedBy
    {
      get { return blockedby; }
    }

    public string Source
    {
      get { return source; }
    }

    public string Target
    {
      get { return target; }
    }

    public DamageType Type
    {
      get { return type; }
    }
  }
}
