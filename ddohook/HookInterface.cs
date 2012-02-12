using System;
using System.Collections.Generic;
using System.Text;

namespace DDOHook
{
  public class HookInterface : MarshalByRefObject
  {
    public virtual void IsInstalled(int pid)
    {
    }

    public virtual void OnNewCombatLog(int pid, string message)
    {
    }

    public virtual void OnLog(string msg)
    {
    }

    public virtual void OnError(string error)
    {
    }

    public virtual void Exiting()
    {
    }
  }
}
