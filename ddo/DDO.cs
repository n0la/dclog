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
using System.Runtime.InteropServices;
using System.IO;
using System.IO.Pipes;
using EasyHook;
using LibDDO.Combat;
using LibDDO.Combat.DPS;

namespace LibDDO
{
  public class DDO
  {
    private static DDO instance = new DDO();
    private Thread pipethread = null;
    private string pipename = "";
    private NamedPipeServerStream pipe = null;

    private ChatLog chatlog = new ChatLog();
    private List<IChatListener> listeners = new List<IChatListener>();

    public delegate void DDONotifyDelegate(DDO sender, string message);
    public delegate void DDOOnChatMessage(DDO sender, ChatMessage message);

    public event DDONotifyDelegate OnNotify;
    public event DDOOnChatMessage OnChatMessage;

    // The entire DDO instance is one language.
    private ILanguageParser parser = new EnglishParser();

    public void Notify(string message)
    {
      Helper.RaiseEventOnUIThread(OnNotify, new object[] { this, message });
    }

    private DDO()
    {
    }

    /// <summary>
    /// Log of all messages.
    /// </summary>
    public ChatLog ChatLog
    {
      get { return chatlog; }
    }

    /// <summary>
    /// Register the given combat log listener to receive a copy of incoming combat log messages.
    /// </summary>
    /// <param name="meter"></param>
    public void RegisterListener(IChatListener meter)
    {
      listeners.Add(meter);
    }

    /// <summary>
    /// Remove a given listener from the list.
    /// </summary>
    /// <param name="meter"></param>
    public void DeregisterListener(IChatListener meter)
    {
      listeners.Remove(meter);
    }

    private void HandleMeters(ChatMessage msg)
    {
      foreach (IChatListener m in listeners)
      {
        m.OnChatMessage(msg);
      }
    }

    /// <summary>
    /// Manually add a combat log message by string.
    /// </summary>
    /// <param name="msg">Combat log message to parse and add.</param>
    public void AddMessage(string m)
    {      
      ChatMessage msg = ChatMessage.Parse(m);

      // Is it even a chat message?
      if (msg != null)
      {
        // If so, which one is it?
        msg = parser.Parse(msg);
        Helper.RaiseEventOnUIThread(OnChatMessage, new object[] { this, msg });
        HandleMeters(msg);

        chatlog.Add(msg);
      }
    }

    public static DDO Instance
    {
      get { return instance; }
    }

    private static void PipeThreadHandler(object obj)
    {
      DDO me = obj as DDO;

      try
      {
        me.pipe.WaitForConnection();
        me.Notify("Hook DLL connected!");

        StreamReader reader = new StreamReader(me.pipe, Encoding.Unicode);

        while (true)
        {
          if (!me.pipe.IsConnected)
          {
            me.Notify("Client disconnected, or game closed.");
            return;
          }

          string message = reader.ReadLine();

          if (message != null)
          {
            if (message.StartsWith("MSG:"))
            {
              message = message.Substring(4);
              me.AddMessage(message);
            }
          }
        }
      }
      catch (Exception e)
      {
        me.Notify("Pipe error:\r\n" + e.ToString());
      }
    }

    /// <summary>
    /// Hook onto a DDO Process 
    /// </summary>
    /// <param name="pid">PID of the process to hook to.</param>
    public void HookOnto(int pid)
    {
      pipename = String.Format("ddohook{0}", pid);
      pipe = new NamedPipeServerStream(pipename, PipeDirection.InOut);
      pipethread = new Thread(PipeThreadHandler);

      pipethread.Start(this);
      Thread.Sleep(200);

      Notify(string.Format("Listening for connections on a named pipe called '{0}'.\n", pipename));
      NativeAPI.RhInjectLibrary(pid, 0, NativeAPI.EASYHOOK_INJECT_DEFAULT, "nativeddohook.dll", null, IntPtr.Zero, 0);
    
      Notify(string.Format("Waiting for an answer from PID {0}...", pid));
    }
  }
}
