using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dclog
{
  public class Logger
  {
    public delegate void DOnNewLog(Logger sender, string message);

    public event DOnNewLog OnNewLog;

    private List<string> messages = new List<string>();
    private Dictionary<LogSeverity, bool> allowed = new Dictionary<LogSeverity, bool>();

    public Logger()
    {
    }

    public enum LogSeverity : int {
      Info,
      Error,
      Verbose,
      Debug,
      Warning
    };

    public void EnableSeverity ( LogSeverity l, bool value ) {
      allowed[l] = value;
    }

    public void EnableAll()
    {
      EnableSeverity(LogSeverity.Verbose, true);
      EnableSeverity(LogSeverity.Error, true);
      EnableSeverity(LogSeverity.Info, true);
      EnableSeverity(LogSeverity.Debug, true);
      EnableSeverity(LogSeverity.Warning, true);
    }

    public void DisableAll()
    {
      EnableSeverity(LogSeverity.Verbose, false);
      EnableSeverity(LogSeverity.Error, false);
      EnableSeverity(LogSeverity.Info, false);
      EnableSeverity(LogSeverity.Debug, false);
      EnableSeverity(LogSeverity.Warning, false);
    }

    public bool IsAllowed(LogSeverity l)
    {
      bool value = false;
      allowed.TryGetValue(l, out value);
      return value;
    }

    public void Info(string msg)
    {
      Log(LogSeverity.Info, msg);
    }

    public void Verbose(string msg)
    {
      Log(LogSeverity.Verbose, msg);
    }

    public void Error(string msg)
    {
      Log(LogSeverity.Error, msg);
    }

    public void Debug(string msg)
    {
      Log(LogSeverity.Debug, msg);
    }

    public void Warning(string msg)
    {
      Log(LogSeverity.Warning, msg);
    }

    public void Log(LogSeverity sev, string message)
    {
      StringBuilder b = new StringBuilder();

      b.Append(DateTime.Now.ToShortDateString());
      b.Append(" ");
      b.Append(DateTime.Now.ToShortTimeString());
      b.Append(": ");

      switch (sev)
      {
        case LogSeverity.Info: b.Append("(II): "); break;
        case LogSeverity.Error: b.Append("(EE): "); break;
        case LogSeverity.Debug: b.Append("(DD): "); break;
        case LogSeverity.Verbose: b.Append("(VV): "); break;
        case LogSeverity.Warning: b.Append("(WW): "); break;
      }
      b.Append(message);
      messages.Add(message.ToString());

      if (IsAllowed(sev))
      {
        if (OnNewLog != null)
        {
          OnNewLog(this, message.ToString());
        }
      }
    }
  }
}
