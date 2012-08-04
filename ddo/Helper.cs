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
using System.ComponentModel;

namespace LibDDO
{
  /// <summary>
  /// Various helper methods.
  /// </summary>
  public class Helper
  {
    public static string RandomString()
    {
      return System.IO.Path.GetRandomFileName().Replace(".", "");
    }

    /// <summary>
    /// This method calls the given event with the specified parameters either synchronized when the
    /// target and caller thread are the same, or asynchronized if the target and caller are in 
    /// different threads.
    /// </summary>
    /// <param name="theEvent">The event to be emitted.</param>
    /// <param name="args">List of parameters passed to the event.</param>
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
