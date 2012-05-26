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
  /// This class is a list of chat log messages, and also keeps track
  /// of other messages seperately.
  /// </summary>
  public class ChatLog
  {
    private List<CombatMessage> combatlog = new List<CombatMessage>();
    private List<ChatMessage> chatlog = new List<ChatMessage>();

    /// <summary>
    /// Constructs a new chat log with a user defined language.
    /// </summary>
    /// <param name="p">Language of the combat log.</param>
    public ChatLog()
    {
    }

    /// <summary>
    /// Chronological list of chat log messages.
    /// </summary>
    public List<ChatMessage> Messages
    {
      get { return chatlog; }
    }

    public List<CombatMessage> CombatLog
    {
      get { return combatlog; }
    }

    /// <summary>
    /// Adds a new chat log message.
    /// </summary>
    /// <param name="msg">Message to parse and add.</param>
    public void Add(ChatMessage msg)
    {
      chatlog.Add(msg);
      if (msg.IsCombat)
      {
        CombatMessage c = msg as CombatMessage;
        combatlog.Add(c);
      }
    }
  }
}
