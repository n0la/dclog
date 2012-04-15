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
using System.Windows.Forms;

namespace dclog
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      MainWindow wnd = new MainWindow();
      FileLogger logger = null;

      if (args.Contains("-d") || args.Contains("--devel"))
      {
          wnd.CreateDeveloper();
      }

      try
      {
        Configuration c = Configuration.Instance;
        c.Load();

        logger = new FileLogger();
        // Run logger.
        logger.Open();
        // Register it at the master instance so it gets notified on new messages.
        LibDDO.DDO.Instance.RegisterListener(logger);
      }
      catch (Exception ex)
      {
        MessageBox.Show(wnd,
                        "There appears to be an error with the configuration file:\r\n"
                        + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
      }

      Application.Run(wnd);

      try
      {
        Configuration c = Configuration.Instance;
        c.Save();

        logger.Close();
      }
      catch (Exception ex)
      {
        MessageBox.Show(null,
                        "There appears to be an error with the configuration file:\r\n"
                        + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
      }
    }
  }
}
