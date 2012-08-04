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
using System.Text.RegularExpressions;
using System.Text;

namespace LibDDO
{
  public enum ChatMessageState : int
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

  public enum MessageType : int
  {
    /// <summary>
    /// Unknown
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Combat message.
    /// </summary>
    Combat,

    /// <summary>
    /// Standard message.
    /// </summary>
    Standard,

    /// <summary>
    /// Advancement message.
    /// </summary>
    Advancement
  }

  public class ChatMessage
  {
    private static Regex r = new Regex(@"\((\w+)\)\s*([^$]+)", RegexOptions.Compiled);

    private string type = "";
    private string text = "";
    private string message = "";
    private DateTime timestamp;
    private ChatMessageState state = ChatMessageState.Unknown;
    private StringBuilder b = new StringBuilder();
    private StringBuilder orig = new StringBuilder();

    public static ChatMessage Parse(string s)
    {
      Match m = r.Match(s);
      ChatMessage msg = null;

      if (m.Success)
      { // Yay, success!
        msg = new ChatMessage(m.Groups[1].Value, m.Groups[2].Value);
      }
      return msg;
    }

    public ChatMessage(string type, string text)
    {
      this.text = text;
      this.type = type;
      this.message = string.Format("({0}) {1}", type, text);
      timestamp = DateTime.Now;
    }

    public ChatMessage(ChatMessage msg)
    {
      this.text = msg.text;
      this.type = msg.type;
      this.message = msg.message;
      this.timestamp = msg.timestamp;
      this.state = msg.state;
      this.orig = msg.orig;
      this.b = msg.b;
    }

    public ChatMessageState State
    {
      get { return state; }
      set { state = value; }
    }


    /// <summary>
    /// Converts this combat log message to the original string as it appeared in the game.
    /// </summary>
    /// <returns>The games representation of the combat log message.</returns>
    public string ToOriginalString()
    {
      if (orig.Length == 0)
      {
        orig.Append("(");
        orig.Append(Type);
        orig.Append("): ");
        orig.Append(Text);
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
        if (state == ChatMessageState.Unknown)
        {
          b.Append("[??] ");
        }
        else if (state == ChatMessageState.ParsingError)
        {
          b.Append("[EE] ");
        }
        else if (state == ChatMessageState.Parsed)
        {
          b.Append("[OK] ");
        }

        b.Append(timestamp.ToLongTimeString());
        b.Append("+");
        b.Append(timestamp.Millisecond);
        b.Append(": ");
        b.Append(message);
      }

      return b.ToString();
    }

    public DateTime TimeStamp
    {
      get { return timestamp; }
    }

    /// <summary>
    /// The text content of the chat message.
    /// </summary>
    public string Text
    {
      get { return text; }
    }

    /// <summary>
    /// The type of the message.
    /// </summary>
    public string Type
    {
      get { return type; }
    }

    public virtual MessageType MessageType
    {
      get { return MessageType.Unknown; }
    }

    /// <summary>
    /// The full message, i.e. (Type) Text
    /// </summary>
    public string Message
    {
      get { return message; }
    }

    public bool IsCombat
    {
      get { return MessageType == MessageType.Combat; }
    }
  }
}
