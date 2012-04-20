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
using System.Runtime.Remoting;
using System.Threading;
using System.ComponentModel;
using EasyHook;
using LibDDO.Combat;
using LibDDO.Combat.DPS;

namespace LibDDO
{
  public class DDO
  {
    private static DDO instance = new DDO();
    private string channelname = null;
    private CombatLog combatlog = new CombatLog();
    private List<ICombatLogListener> listeners = new List<ICombatLogListener>();
    private StringBuilder strings = new StringBuilder();

    public delegate void DDONotifyDelegate(DDO sender, string message);
    public delegate void DDOOnCombatLogMessageDelegate(DDO sender, CombatLogMessage message);
    public delegate void DDOOnStringDelegate(DDO sender, string str);

    public event DDONotifyDelegate OnNotify;
    public event DDOOnCombatLogMessageDelegate OnCombatLogMessage;
    public event DDOOnStringDelegate OnString;

    public void Notify(string message)
    {
      Helper.RaiseEventOnUIThread(OnNotify, new object[] { this, message });
    }

    private DDO()
    {
    }

    public void OtherString(string msg)
    {
      strings.AppendLine(msg);
      Helper.RaiseEventOnUIThread(OnString, new object[] { this, msg });
    }

    public CombatLog CombatLog 
    { 
      get { return combatlog; } 
    }

    public void RegisterListener(ICombatLogListener meter)
    {
      listeners.Add(meter);
    }

    public void DeregisterListener(ICombatLogListener meter)
    {
      listeners.Remove(meter);
    }

    private void HandleMeters(CombatLogMessage msg)
    {
      foreach (ICombatLogListener m in listeners)
      {
        m.OnCombatLog(msg);
      }
    }

    public void AddCombatLogMessage(string msg)
    {
      CombatLogMessage e = new CombatLogMessage(msg);
      combatlog.Add(e);
      HandleMeters(e);
      Helper.RaiseEventOnUIThread(OnCombatLogMessage, new object[] { this, e });      
    }

    public static DDO Instance
    {
      get { return instance; }
    }

    /// <summary>
    /// Hook onto a DDO Process 
    /// </summary>
    /// <param name="pid">PID of the process to hook to.</param>
    public void HookOnto(int pid)
    {      
      Config.Register("Hooks into DDO.", "ddohook.dll");

      RemoteHooking.IpcCreateServer<DDOHookInterface>(ref channelname, WellKnownObjectMode.SingleCall);
      RemoteHooking.Inject(pid,
                           "ddohook.dll",
                           "doohook.dll",
                           channelname
                           );      
      Notify(string.Format("Successfully hooked onto {0}", pid));
    }
  }
}
