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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using DCLog.Plugins;
using System.Text;
using System.Windows.Forms;

namespace dclog
{
  public partial class PluginManager : Form
  {
    private Plugins plugins = null;

    public PluginManager(Plugins p)
    {
      plugins = p;
      InitializeComponent(); 
    }

    private bool IsBlackListed(string name)
    {
      return (Configuration.Instance.PluginBlackList.Contains(name));
    }

    private void PluginManager_Load(object sender, EventArgs e)
    {
      foreach (IPlugin p in plugins.AvailablePlugins)
      {
        ListViewItem item = new ListViewItem();

        item.SubItems.Add(p.Name);
        item.SubItems.Add(p.Description);
        item.SubItems.Add(p.Version.ToString());

        item.Checked = !IsBlackListed(p.Name);

        plist.Items.Add(item);
      }
    }

    private void okay_Click(object sender, EventArgs e)
    {
      Configuration.Instance.PluginBlackList.Clear();
      foreach (ListViewItem i in plist.Items)
      {
        if (!i.Checked)
        { // Add module to blacklist
          Configuration.Instance.PluginBlackList.Add(i.SubItems[1].Text);
        }
      }
      DialogResult = DialogResult.OK;
      Close();
    }

    private void cancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      Close();
    }
  }
}
