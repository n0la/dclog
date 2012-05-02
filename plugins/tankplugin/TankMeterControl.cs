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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using LibDDO;
using LibDDO.Combat.Tanking;

namespace DCLog.DPSPlugin
{
  public partial class TankMeterControl : UserControl
  {
    private DDO instance = null;
    private SimpleTankMeter stm = new SimpleTankMeter();
    private TankMeterByMonster tmb = new TankMeterByMonster();
    private TankMeterByType tmt = new TankMeterByType();

    public TankMeterControl()
    {
      InitializeComponent();
    }

    public TankMeterControl(LibDDO.DDO instance)
    {
      this.instance = instance;
      InitializeComponent();

      instance.RegisterListener(stm);
      instance.RegisterListener(tmb);
      instance.RegisterListener(tmt);
    }

    private void tankmeter_AfterSelect(object sender, TreeViewEventArgs e)
    {
      tankrefresh_Click(sender, e);
    }

    private void RefreshSimple()
    {
      Series cur = tankchart.Series[0];
      cur.Points.Clear();
      cur.Points.Add(ChartHelper.CreateNamedPoint("Damage taken", stm.DamageTaken));
      cur.Points.Add(ChartHelper.CreateNamedPoint("Damage blocked", stm.DamageBlocked));
      NoTotal();
    }


    public TreeNode FindByTag(TreeNode parent, string tag)
    {
      for (int i = 0; i < parent.Nodes.Count; i++)
      {
        TreeNode child = parent.Nodes[i];
        if ((child.Tag as string) == tag)
        {
          return child;
        }
      }
      return null;
    }

    private void AddMonsters()
    {
      var nodes = tankmeter.Nodes.Find("monster", false);

      if (nodes.Length == 1)
      {
        TreeNode node = nodes[0];
        // Add new child elements in case they are not there yet.
        foreach (var p in tmb.DamageValues)
        {
          var exists = node.Nodes.Find(p.Key, true);
          if (exists.Length == 0)
          {
            TreeNode ny = new TreeNode(p.Key);
            TreeNode byattack = new TreeNode("By ability");
            TreeNode blockratio = new TreeNode("Block ratio");

            ny.Tag = "monster";
            ny.Name = p.Key;

            byattack.Tag = "monster";
            byattack.Name = "byability";

            blockratio.Tag = "monster";
            blockratio.Name = "blockratio";

            ny.Nodes.Add(byattack);
            ny.Nodes.Add(blockratio);

            node.Nodes.Add(ny);
          }
        }
      }
    }

    private void RefreshByMonster()
    {
      TreeNode node = tankmeter.SelectedNode;

      if (node.Parent == null)
      { // Parent node selected, show a summary. The summary is provided by TankMeterByMonster
        Series cur = tankchart.Series[0];
        cur.Points.Clear();

        foreach (var p in tmb.Summary)
        {
          cur.Points.Add(ChartHelper.CreateNamedPoint(p.Key, p.Value.Points));
        }
        AddTotal();
      }
      else if (node.Name == "byability")
      { // By ability has been selected, display damage by attacks done by the monster.
        Series cur = tankchart.Series[0];
        cur.Points.Clear();

        if (!tmb.DamageValues.ContainsKey(node.Parent.Text))
        { // Error
          return;
        }

        MonsterDamage dmg = tmb.DamageValues[node.Parent.Text];
        foreach (var p in dmg)
        {
          cur.Points.Add(ChartHelper.CreateNamedPoint(p.Key, p.Value.Points));
        }
        AddTotal();
      }
      else if (node.Name == "blockratio")
      { // The taken/blocked ratio for that monster
        Series cur = tankchart.Series[0];
        cur.Points.Clear();

        if (!tmb.Summary.ContainsKey(node.Parent.Text))
        {
          return;
        }

        var summary = tmb.Summary[node.Parent.Text];
        cur.Points.Add(ChartHelper.CreateNamedPoint("Damage taken", summary.Points));
        cur.Points.Add(ChartHelper.CreateNamedPoint("Damage blocked", summary.Blocked));
        NoTotal();
      }
    }

    private void RefreshByType()
    {
      Series cur = tankchart.Series[0];

      cur.Points.Clear();

      foreach (var p in tmt.DamageValues)
      {
        cur.Points.Add(ChartHelper.CreateNamedPoint(p.Key.ToString(), p.Value.Points));
      }
      AddTotal();
    }

    private void NoTotal()
    {
      tankchart.Legends[0].CustomItems.Clear();
    }


    /// <summary>
    /// Add a "Total #value" as the last data point.
    /// </summary>
    /// <param name="points"></param>
    private void AddTotal()
    {
      double total = 0;

      foreach (var p in tankchart.Series[0].Points)
      {
        total += p.XValue;
      }

      LegendItem item = new LegendItem();
      item.Name = string.Format("Total: {0}", total);
      item.Color = Color.Pink;
      item.BorderWidth = 0;

      tankchart.Legends[0].CustomItems.Clear();
      tankchart.Legends[0].CustomItems.Add(item);
    }

    /**
     * Damage received            ~ Entire damage received, show blocked/received ratio
     * Damage received by type    ~ Entire damage received sorted by type
     * Damage received by monster ~ Show damage done by monsters, 
     *                              i.e. which monster has done the most damage?
     *  o Monster                 ~ TODO
     *    o By attack             ~ Show damage done by specific attack.
     *    o By type               ~ Show damage done by monster sorted by type. TODO
     *    
     * The three root nodes all have tags. The tags are:
     *  Damage received: simple
     *  Damage received by type: type
     *  Damage received by monster: monster
     * Child nodes of these should have the same tag for the trigger to work. Each update
     * method can use the Name property to differentiate the child nodes.
     * 
     * **TODO** Find better way for node handling.
     */
    private void tankrefresh_Click(object sender, EventArgs e)
    {
      // Make sure monsters are added as soon as possible.
      AddMonsters();

      if (tankmeter.SelectedNode == null)
      {
        return;
      }
      string selected = tankmeter.SelectedNode.Tag as string;

      switch (selected)
      {
        case "simple": RefreshSimple(); break;
        case "monster": RefreshByMonster(); break;
        case "type": RefreshByType(); break;
      }
    }

    private void tanktimer_Tick(object sender, EventArgs e)
    {
      this.tankrefresh_Click(sender, e);
    }
  }
}
