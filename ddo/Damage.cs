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
  public enum DamageType : int
  {
    [StringValue("Unkown")]
    Unknown = 0,
    [StringValue("Slashing")]
    Slashing,
    [StringValue("Piercing")]
    Piercing,
    [StringValue("Bludgeoning")]
    Bludgeoning,
    [StringValue("Acid")]
    Acid,
    [StringValue("Fire")]
    Fire,
    [StringValue("Good")]
    Good,
    [StringValue("Cold")]
    Cold,
    [StringValue("Shock")]
    Shock,
    [StringValue("Chaotic")]
    Chaotic,
    [StringValue("Sonic")]
    Sonic,
    [StringValue("Force")]
    Force,
    [StringValue("Evil")]
    Evil,
    [StringValue("Lawful")]
    Lawful,
  }

  public class Damage
  {
    private uint points = 0;
    private uint blocked = 0;
    private string blockedby = "";
    private string source = "";
    private string sourceability = "";
    private string target = "";
    private string targetability = "";
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
    /// Damage potential (i.e. points + blocked)
    /// </summary>
    public uint PotentialDamage
    {
      get 
      {
        uint pot = points + blocked;
        return pot;
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
      set { source = value; }
    }

    public string Target
    {
      get { return target; }
      set { target = value; }
    }

    public string SourceAbility
    {
      get { return sourceability; }
      set { sourceability = value; }
    }

    public string TargetAbility
    {
      get { return targetability; }
      set { targetability = value; }
    }

    public DamageType Type
    {
      get { return type; }
    }

    public static Damage operator + ( Damage a, Damage d ) {
      a.points += d.points;
      a.blocked += d.blocked;

      return a;
    }
  }
}
