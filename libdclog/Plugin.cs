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
  /// <summary>
  /// Base interface for all plugins to DCLog.
  /// 
  /// While a plugin serves one or many custom made controls which are displayed by the main
  /// application. All actions, sub controls (charts, text boxes, buttons) are to be
  /// handled by those controls. While a plugin may provide more than one UI control, it is
  /// generally recommended to have one plugin for one control. Each plugin assembly can provide
  /// more than one plugin though; i.e. a DPS plugin can provide several different DPS meters.
  /// 
  /// It is good design to create and initialise controls upon the first call to the Controls
  /// property. This way maximum performance of DCLog is ensured.
  /// </summary>
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
    /// the singleton LibDDO.DDO, as the singleton design is subject to change.
    /// </summary>
    /// <param name="instance"></param>
    void Initialise(LibDDO.DDO instance);

    /// <summary>
    /// Is called when the plugin is destroyed the main window. Use it to free up resources that
    /// are otherwise not managed by the garbage collector.
    /// </summary>
    void Destroy();

    /// <summary>
    /// A list of controls your application wishes to return.
    /// </summary>
    /// <returns>Control with children.</returns>
    List<Control> Controls { get; }

  }
}
