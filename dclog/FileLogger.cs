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
using LibDDO.Combat;
using System.Threading;
using System.IO;

namespace dclog
{
  public enum LoggingMethod : int
  {
    DateStamped = 0,
  }

  /**
   *  This file logger creates to file logs: 
   *   o date_combatlog.txt, which contains the combat log as it is received; and
   *   o date_statuslog.txt, which contains additional information on how the strings were parsed.
   *  All of them are stamped per date.
   */
  public class FileLogger : ICombatLogListener
  {
    private string logfile = "";
    private string statusfile = "";
    private DateTime started;
    private LoggingMethod method;
    private Thread thread = null;
    private bool stop = true;
    private FileStream stream;
    private StreamWriter writer;
    private FileStream statusstream;
    private StreamWriter status;
    private Exception error;

    private Queue<CombatLogMessage> messages = new Queue<CombatLogMessage>();

    private void OpenFile()
    {
      string logdir = Configuration.Instance.LogDirectory;

      if (!Directory.Exists(logdir))
      {
        Directory.CreateDirectory(logdir);
      }

      if (method == LoggingMethod.DateStamped)
      {
        logfile = string.Format(@"{0}\{1}.{2}.{3}_combatlog.txt",
                                 logdir,
                                 started.Day,
                                 started.Month,
                                 started.Year
                                 );
        statusfile = string.Format(@"{0}\{1}.{2}.{3}_statuslog.txt",
                                 logdir,
                                 started.Day,
                                 started.Month,
                                 started.Year
                                 );
      }
      else
      {
        throw new ApplicationException("Unknown logging method.");
      }

      try
      {
        if (writer != null)
        {
          writer.Flush();
          writer.Close();
        }
        if (status != null)
        {
          status.Flush();
          status.Close();
        }
      }
      catch (Exception)
      { // ignored.
      }

      stream = new FileStream(logfile, FileMode.Append);
      writer = new StreamWriter(stream);

      statusstream = new FileStream(statusfile, FileMode.Append);
      status = new StreamWriter(statusstream);
    }

    public void Open(LoggingMethod method = LoggingMethod.DateStamped)
    {
      if (thread != null && thread.IsAlive)
      {
        return;
      }

      started = DateTime.Now;
      this.method = method;

      OpenFile();

      stop = false;
      thread = new Thread(new ThreadStart(LogMessages));
      thread.Start();
    }

    public void Close()
    {
      if (thread == null || !thread.IsAlive)
      { // not running
        return;
      }

      stop = true;
      // Join the thread until it ends.
      thread.Join();

      writer.Close();
    }

    private void LogMessages()
    {
      try
      {
        while (!stop)
        {
          Thread.Sleep(50);
          DateTime now = DateTime.Now;

          if (started.Day != now.Day)
          { // the a new day begin? If so run open a new file.
            OpenFile();
          }

          lock (messages)
          {
            if (messages.Count != 0)
            { // write one message to file
              CombatLogMessage msg = messages.Dequeue();
              writer.WriteLine(msg.ToOriginalString());
              writer.Flush();
              status.WriteLine(msg.ToString());
              status.Flush();
            }
          }
        }
      }
      catch (Exception ex)
      {
        error = ex;
      }
    }

    public void OnCombatLog(CombatLogMessage msg)
    {
      lock (messages)
      {
        messages.Enqueue(msg);
      }
    }
  }
}
