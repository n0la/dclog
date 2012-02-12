using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ComponentModel;

namespace LibDDO
{
  public class Helper
  {
    public static void RaiseEventOnUIThread(Delegate theEvent, object[] args)
    {
      try
      {
        if (theEvent == null)
        {
          return;
        }

        foreach (Delegate d in theEvent.GetInvocationList())
        {
          ISynchronizeInvoke syncer = d.Target as ISynchronizeInvoke;
          if (syncer == null)
          {
            d.DynamicInvoke(args);
          }
          else
          {
            syncer.BeginInvoke(d, args);  // cleanup omitted
          }
        }
      }
      catch
      {
      }
    }
  }
}
