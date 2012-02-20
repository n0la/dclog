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
using System.Globalization;
using System.Text;

namespace LibDDO
{
  public class StringValue : Attribute
  {
    private string value = "";
    private CultureInfo language = CultureInfo.CreateSpecificCulture("en-GB");

    public StringValue(string value)
    {
      this.value = value;
    }

    public StringValue(string value, CultureInfo language)
    {
      this.value = value;
      this.language = language;
    }

    public CultureInfo Language { get { return language; } }
    public string Value { get { return value; } }
  }
}
