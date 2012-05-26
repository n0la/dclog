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
using System.Text;
using System.Text.RegularExpressions;

namespace DDOHook
{
  public class MessageFilter
  {
    private Regex regex = null;
    private string replacewith;

    /// <summary>
    /// This is a filter for incoming messages. It takes a regular expression to match the string
    /// and a string the regular expression can be replaced with to prettify the string.
    ///  Example:
    ///     MessageFilter f = new MessageFilter(@"^Combat.{1}\):.{1}", "Combat");
    /// The replacewith "Combat" is automatically converted to "(Combat) " to conform to LibDDO.
    /// </summary>
    /// <param name="regex"></param>
    /// <param name="replacewith"></param>
    public MessageFilter(string regex, string replacewith)
    {
      this.regex = new Regex(regex, RegexOptions.Compiled);
      this.replacewith = "(" + replacewith + ") ";
    }

    public bool Applies(string message)
    {
      return (regex.Match(message).Length > 0);
    }

    public string Prettify(string message)
    {
      return regex.Replace(message, replacewith);
    }
  }
}
