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

    public override void OnNewCombatLog(int pid, string message)
    {
      DDO.Instance.AddCombatLogMessage(message);
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
