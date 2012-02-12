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
