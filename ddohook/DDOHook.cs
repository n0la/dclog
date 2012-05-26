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
using System.Threading;
using EasyHook;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace DDOHook
{
  public class DDOHook : EasyHook.IEntryPoint
  {
    HookInterface iface;
    LocalHook wcsncpyHook;
    Stack<string> stringqueue = new Stack<string>();
    private static MessageFilter combatlog = new MessageFilter(@"^Combat.{1}\):.{2}", "Combat");
    private static MessageFilter standardlog = new MessageFilter(@"^Standard.{1}\):.{2}", "Standard");
    private static MessageFilter advancementlog = new MessageFilter(@"^Advancement.{1}\):.{2}", "Advancement");

    private List<MessageFilter> knownmessages = new List<MessageFilter>() { combatlog, standardlog, advancementlog };

    public DDOHook(RemoteHooking.IContext context, String channel)
    {
      iface = RemoteHooking.IpcConnectClient<HookInterface>(channel);
    }

    public void Run(RemoteHooking.IContext context, String channel)
    {    
      try {
        // Avoid any point that may pass a .NET exception up to DDO itself.
        // Such an exception will crash the game.
        int me = RemoteHooking.GetCurrentProcessId();

        wcsncpyHook = LocalHook.Create(LocalHook.GetProcAddress("MSVCR80.DLL", "wcsncpy"),
                      new Dwcsncpy(wcsncpy_Hooked),
                      this
                      );

        wcsncpyHook.ThreadACL.SetExclusiveACL(new Int32[] { 0 });

        iface.IsInstalled(me);

        while (true)
        {
          Thread.Sleep(50);

          while (stringqueue.Count > 0)
          {
            string str;
            lock (stringqueue)
            {
              str = stringqueue.Pop();
              foreach (MessageFilter r in knownmessages)
              {
                if (r.Applies(str))
                {
                  str = r.Prettify(str);
                  iface.OnNewMessage(me, str);
                }
              }
            }

          }
        }        
      }
      catch (Exception ex)
      {
        try
        {
          iface.OnError(ex.ToString());
        }
        catch (Exception)
        {
        }
      }

      try
      { // We are exiting. Either because we ran into an exception
        // or because we have been signaled or terminated.
        iface.Exiting();
      }
      catch (Exception)
      {
      }
    }

    public void Error(Exception e)
    {
      iface.OnError(e.Message + "\r\n" + e.StackTrace);
    }

    public void Error(string m)
    {
      iface.OnError(m);
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate IntPtr Dwcsncpy(IntPtr str1,
                            IntPtr str2,
                            uint n
                            );

    [DllImport("msvcr80.dll", CallingConvention = CallingConvention.Cdecl)]
    static extern IntPtr wcsncpy(IntPtr str1,
                                 IntPtr str2,
                                 uint n
                                 );

    static IntPtr wcsncpy_Hooked(IntPtr str1, IntPtr str2, uint size)
    {      
      try
      {
        DDOHook me = (DDOHook)HookRuntimeInfo.Callback;
        if (size > 4 && str1 != IntPtr.Zero && str2 != IntPtr.Zero) // Length of Combat
        {
          string src = Marshal.PtrToStringUni(str2);
          lock (me.stringqueue)
          {
            me.stringqueue.Push(src);
          }
        }
      }
      catch (Exception)
      {
      }
      return wcsncpy(str1, str2, size);
    }
  }
}
