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
  public class CombatLog
  {
    private List<CombatLogMessage> combatlog = new List<CombatLogMessage>();
    private ILanguageParser parser = null;

    public CombatLog()
    {
      parser = new EnglishCombatLog();
    }

    public CombatLog(ILanguageParser p)
    {
      parser = p;
    }

    public List<CombatLogMessage> Messages
    {
      get { return combatlog; }
    }

    public void Add(CombatLogMessage msg)
    {
      // Parse the combat log and add it regardless.
      parser.Parse(msg);
      combatlog.Add(msg);
    }
  }
}
