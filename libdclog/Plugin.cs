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
using System.Windows.Forms;
using System.Text;

namespace DCLog.Plugins
{
  public interface IPlugin
  {
    /// <summary>
    /// Name of the module.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// English language description for the plugin.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Name of the author. May include copyright.
    /// </summary>
    string Author { get; }

    /// <summary>
    /// Optional website.
    /// </summary>
    string Website { get; }

    /// <summary>
    /// Version of the plugin.
    /// </summary>
    Version Version { get; }

    /// <summary>
    /// This is called to verify that your plugin works with the provided version of the main application.
    /// </summary>
    /// <param name="v">Version of the main application.</param>
    /// <returns>True if compatible, false otherwise.</returns>
    bool IsCompatible(Version v);

    /// <summary>
    /// Is called once to give you the currently active instance of DDO. Use this instance over
    /// the singleton LibDDO.DDO may be.
    /// </summary>
    /// <param name="instance"></param>
    void Initialise(LibDDO.DDO instance);
    void Destroy();

    /// <summary>
    /// A list of controls your application wishes to return.
    /// </summary>
    /// <returns>Control with children.</returns>
    List<Control> Controls { get; }

  }
}
