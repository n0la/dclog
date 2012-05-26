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

namespace LibDDO
{
  public class DDOHookInterface : DDOHook.HookInterface
  {
    public override void IsInstalled(int pid)
    {
      DDO.Instance.Notify(string.Format("Hook successfuly initialized in pid {0}", pid));
    }

    public override void OnNewMessage(int pid, string message)
    {
      DDO.Instance.AddMessage(message);
    }

    public override void OnLog(string msg)
    {
      DDO.Instance.Notify(msg);
    }

    public override void OnError(string error)
    {
      DDO.Instance.Notify(error);
    }

    public override void Exiting()
    {
    }
  }
}
