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
using System.Windows.Forms;
using System.Text;

namespace DCLog.DPSPlugin
{
  public class CurrentDPSPlugin : DCLog.Plugins.IPlugin
  {
    private LibDDO.DDO instance = null;
    private CurrentDPSControl control = null;

    public string Name
    {
      get { return "Current DPS"; }
    }

    public string Description
    {
      get { return "Calculates the current DPS you did."; }
    }

    public string Author
    {
      get { return "Copyright (C) 2012 by Florian Stinglmayr"; }
    }

    public string Website
    {
      get { return "https://github.com/n0la/dclog"; }
    }

    public Version Version
    {
      get { return new Version(1, 0, 0); }
    }

    public bool IsCompatible(Version v)
    {
      // **TODO** Version check.
      return true;
    }

    public void Initialise(LibDDO.DDO instance)
    {
      this.instance = instance;
    }

    public void Destroy()
    {
    }

    public List<Control> Controls
    {
      get {
        if (control == null)
        {
          control = new CurrentDPSControl(this.instance);
        }
        return new List<Control> { control };
      }
    }
  }
}
