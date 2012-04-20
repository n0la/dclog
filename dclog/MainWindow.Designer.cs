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

namespace dclog
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          this.components = new System.ComponentModel.Container();
          System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
          System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
          System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
          System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
          System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
          System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
          System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Damage received / blocked");
          System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Damage received by type");
          System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Damage received by monster");
          this.mainmenu = new System.Windows.Forms.MenuStrip();
          this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.attach = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
          this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.reportABugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
          this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.maintabs = new System.Windows.Forms.TabControl();
          this.tabPage1 = new System.Windows.Forms.TabPage();
          this.applog = new System.Windows.Forms.TextBox();
          this.tabPage2 = new System.Windows.Forms.TabPage();
          this.combatlog = new System.Windows.Forms.TextBox();
          this.tabPage3 = new System.Windows.Forms.TabPage();
          this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
          this.groupBox1 = new System.Windows.Forms.GroupBox();
          this.ststatus = new System.Windows.Forms.Label();
          this.ststop = new System.Windows.Forms.Button();
          this.ststart = new System.Windows.Forms.Button();
          this.sttarget = new System.Windows.Forms.ComboBox();
          this.label1 = new System.Windows.Forms.Label();
          this.dpschart = new System.Windows.Forms.DataVisualization.Charting.Chart();
          this.tabPage4 = new System.Windows.Forms.TabPage();
          this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
          this.tankchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
          this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
          this.tankrefresh = new System.Windows.Forms.Button();
          this.tanktimer = new System.Windows.Forms.Timer(this.components);
          this.feedTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.feedFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
          this.tankmeter = new System.Windows.Forms.TreeView();
          this.mainmenu.SuspendLayout();
          this.maintabs.SuspendLayout();
          this.tabPage1.SuspendLayout();
          this.tabPage2.SuspendLayout();
          this.tabPage3.SuspendLayout();
          this.tableLayoutPanel1.SuspendLayout();
          this.groupBox1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.dpschart)).BeginInit();
          this.tabPage4.SuspendLayout();
          this.tableLayoutPanel2.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.tankchart)).BeginInit();
          this.tableLayoutPanel3.SuspendLayout();
          this.SuspendLayout();
          // 
          // mainmenu
          // 
          this.mainmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
          this.mainmenu.Location = new System.Drawing.Point(0, 0);
          this.mainmenu.Name = "mainmenu";
          this.mainmenu.Size = new System.Drawing.Size(877, 24);
          this.mainmenu.TabIndex = 0;
          this.mainmenu.Text = "menuStrip1";
          // 
          // fileToolStripMenuItem
          // 
          this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.attach,
            this.toolStripSeparator3,
            this.feedFileToolStripMenuItem,
            this.feedTextToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
          this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
          this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
          this.fileToolStripMenuItem.Text = "File";
          // 
          // attach
          // 
          this.attach.Name = "attach";
          this.attach.Size = new System.Drawing.Size(152, 22);
          this.attach.Text = "Attach...";
          this.attach.Click += new System.EventHandler(this.attach_Click);
          // 
          // toolStripSeparator1
          // 
          this.toolStripSeparator1.Name = "toolStripSeparator1";
          this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
          // 
          // quitToolStripMenuItem
          // 
          this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
          this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
          this.quitToolStripMenuItem.Text = "Quit";
          this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
          // 
          // helpToolStripMenuItem
          // 
          this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportABugToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem});
          this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
          this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
          this.helpToolStripMenuItem.Text = "Help";
          // 
          // reportABugToolStripMenuItem
          // 
          this.reportABugToolStripMenuItem.Name = "reportABugToolStripMenuItem";
          this.reportABugToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
          this.reportABugToolStripMenuItem.Text = "Report a bug";
          this.reportABugToolStripMenuItem.Click += new System.EventHandler(this.reportABugToolStripMenuItem_Click);
          // 
          // toolStripSeparator2
          // 
          this.toolStripSeparator2.Name = "toolStripSeparator2";
          this.toolStripSeparator2.Size = new System.Drawing.Size(139, 6);
          // 
          // aboutToolStripMenuItem
          // 
          this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
          this.aboutToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
          this.aboutToolStripMenuItem.Text = "About";
          this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
          // 
          // maintabs
          // 
          this.maintabs.Controls.Add(this.tabPage1);
          this.maintabs.Controls.Add(this.tabPage2);
          this.maintabs.Controls.Add(this.tabPage3);
          this.maintabs.Controls.Add(this.tabPage4);
          this.maintabs.Dock = System.Windows.Forms.DockStyle.Fill;
          this.maintabs.Location = new System.Drawing.Point(0, 24);
          this.maintabs.Name = "maintabs";
          this.maintabs.SelectedIndex = 0;
          this.maintabs.Size = new System.Drawing.Size(877, 457);
          this.maintabs.TabIndex = 1;
          // 
          // tabPage1
          // 
          this.tabPage1.Controls.Add(this.applog);
          this.tabPage1.Location = new System.Drawing.Point(4, 22);
          this.tabPage1.Name = "tabPage1";
          this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
          this.tabPage1.Size = new System.Drawing.Size(869, 431);
          this.tabPage1.TabIndex = 0;
          this.tabPage1.Text = "Application log";
          this.tabPage1.UseVisualStyleBackColor = true;
          // 
          // applog
          // 
          this.applog.Dock = System.Windows.Forms.DockStyle.Fill;
          this.applog.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.applog.Location = new System.Drawing.Point(3, 3);
          this.applog.Multiline = true;
          this.applog.Name = "applog";
          this.applog.ReadOnly = true;
          this.applog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
          this.applog.Size = new System.Drawing.Size(863, 425);
          this.applog.TabIndex = 0;
          this.applog.TextChanged += new System.EventHandler(this.applog_TextChanged);
          // 
          // tabPage2
          // 
          this.tabPage2.Controls.Add(this.combatlog);
          this.tabPage2.Location = new System.Drawing.Point(4, 22);
          this.tabPage2.Name = "tabPage2";
          this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
          this.tabPage2.Size = new System.Drawing.Size(869, 431);
          this.tabPage2.TabIndex = 1;
          this.tabPage2.Text = "Combat Log";
          this.tabPage2.UseVisualStyleBackColor = true;
          // 
          // combatlog
          // 
          this.combatlog.Dock = System.Windows.Forms.DockStyle.Fill;
          this.combatlog.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.combatlog.Location = new System.Drawing.Point(3, 3);
          this.combatlog.Multiline = true;
          this.combatlog.Name = "combatlog";
          this.combatlog.ReadOnly = true;
          this.combatlog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
          this.combatlog.Size = new System.Drawing.Size(863, 425);
          this.combatlog.TabIndex = 0;
          this.combatlog.TextChanged += new System.EventHandler(this.combatlog_TextChanged);
          // 
          // tabPage3
          // 
          this.tabPage3.Controls.Add(this.tableLayoutPanel1);
          this.tabPage3.Location = new System.Drawing.Point(4, 22);
          this.tabPage3.Name = "tabPage3";
          this.tabPage3.Size = new System.Drawing.Size(869, 431);
          this.tabPage3.TabIndex = 2;
          this.tabPage3.Text = "Single Target DPS";
          this.tabPage3.UseVisualStyleBackColor = true;
          // 
          // tableLayoutPanel1
          // 
          this.tableLayoutPanel1.ColumnCount = 1;
          this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
          this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
          this.tableLayoutPanel1.Controls.Add(this.dpschart, 0, 1);
          this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
          this.tableLayoutPanel1.Name = "tableLayoutPanel1";
          this.tableLayoutPanel1.RowCount = 2;
          this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
          this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
          this.tableLayoutPanel1.Size = new System.Drawing.Size(869, 431);
          this.tableLayoutPanel1.TabIndex = 3;
          // 
          // groupBox1
          // 
          this.groupBox1.Controls.Add(this.ststatus);
          this.groupBox1.Controls.Add(this.ststop);
          this.groupBox1.Controls.Add(this.ststart);
          this.groupBox1.Controls.Add(this.sttarget);
          this.groupBox1.Controls.Add(this.label1);
          this.groupBox1.Location = new System.Drawing.Point(3, 3);
          this.groupBox1.MaximumSize = new System.Drawing.Size(324, 100);
          this.groupBox1.MinimumSize = new System.Drawing.Size(324, 100);
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.Size = new System.Drawing.Size(324, 100);
          this.groupBox1.TabIndex = 3;
          this.groupBox1.TabStop = false;
          this.groupBox1.Text = "Target";
          // 
          // ststatus
          // 
          this.ststatus.AutoSize = true;
          this.ststatus.ForeColor = System.Drawing.Color.Red;
          this.ststatus.Location = new System.Drawing.Point(207, 71);
          this.ststatus.Name = "ststatus";
          this.ststatus.Size = new System.Drawing.Size(56, 13);
          this.ststatus.TabIndex = 4;
          this.ststatus.Text = "Stopped...";
          // 
          // ststop
          // 
          this.ststop.Location = new System.Drawing.Point(91, 71);
          this.ststop.Name = "ststop";
          this.ststop.Size = new System.Drawing.Size(75, 23);
          this.ststop.TabIndex = 3;
          this.ststop.Text = "Stop";
          this.ststop.UseVisualStyleBackColor = true;
          this.ststop.Click += new System.EventHandler(this.ststop_Click);
          // 
          // ststart
          // 
          this.ststart.Location = new System.Drawing.Point(10, 71);
          this.ststart.Name = "ststart";
          this.ststart.Size = new System.Drawing.Size(75, 23);
          this.ststart.TabIndex = 2;
          this.ststart.Text = "Start";
          this.ststart.UseVisualStyleBackColor = true;
          this.ststart.Click += new System.EventHandler(this.ststart_Click);
          // 
          // sttarget
          // 
          this.sttarget.FormattingEnabled = true;
          this.sttarget.Items.AddRange(new object[] {
            "Training Dummy"});
          this.sttarget.Location = new System.Drawing.Point(141, 20);
          this.sttarget.Name = "sttarget";
          this.sttarget.Size = new System.Drawing.Size(177, 21);
          this.sttarget.TabIndex = 1;
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(7, 20);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(127, 13);
          this.label1.TabIndex = 0;
          this.label1.Text = "Select or specify a target:";
          // 
          // dpschart
          // 
          chartArea1.AxisX.Title = "Seconds";
          chartArea1.AxisY.Title = "DPS";
          chartArea1.Name = "ChartArea1";
          this.dpschart.ChartAreas.Add(chartArea1);
          this.dpschart.Dock = System.Windows.Forms.DockStyle.Fill;
          legend1.Name = "Legend1";
          this.dpschart.Legends.Add(legend1);
          this.dpschart.Location = new System.Drawing.Point(3, 113);
          this.dpschart.Name = "dpschart";
          series1.ChartArea = "ChartArea1";
          series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
          series1.Legend = "Legend1";
          series1.Name = "DPS";
          this.dpschart.Series.Add(series1);
          this.dpschart.Size = new System.Drawing.Size(863, 315);
          this.dpschart.TabIndex = 4;
          this.dpschart.Text = "Single Target DPS";
          // 
          // tabPage4
          // 
          this.tabPage4.Controls.Add(this.tableLayoutPanel2);
          this.tabPage4.Location = new System.Drawing.Point(4, 22);
          this.tabPage4.Name = "tabPage4";
          this.tabPage4.Size = new System.Drawing.Size(869, 431);
          this.tabPage4.TabIndex = 3;
          this.tabPage4.Text = "Tank Meter";
          this.tabPage4.UseVisualStyleBackColor = true;
          // 
          // tableLayoutPanel2
          // 
          this.tableLayoutPanel2.ColumnCount = 2;
          this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
          this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
          this.tableLayoutPanel2.Controls.Add(this.tankchart, 1, 0);
          this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
          this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
          this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
          this.tableLayoutPanel2.Name = "tableLayoutPanel2";
          this.tableLayoutPanel2.RowCount = 1;
          this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
          this.tableLayoutPanel2.Size = new System.Drawing.Size(869, 431);
          this.tableLayoutPanel2.TabIndex = 0;
          // 
          // tankchart
          // 
          chartArea2.Name = "ChartArea1";
          this.tankchart.ChartAreas.Add(chartArea2);
          this.tankchart.Dock = System.Windows.Forms.DockStyle.Fill;
          legend2.Name = "Legend1";
          this.tankchart.Legends.Add(legend2);
          this.tankchart.Location = new System.Drawing.Point(203, 3);
          this.tankchart.Name = "tankchart";
          series2.ChartArea = "ChartArea1";
          series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
          series2.Legend = "Legend1";
          series2.Name = "Series1";
          series2.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.No;
          this.tankchart.Series.Add(series2);
          this.tankchart.Size = new System.Drawing.Size(663, 425);
          this.tankchart.TabIndex = 1;
          this.tankchart.Text = "Tank Chart";
          // 
          // tableLayoutPanel3
          // 
          this.tableLayoutPanel3.ColumnCount = 1;
          this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
          this.tableLayoutPanel3.Controls.Add(this.tankrefresh, 0, 1);
          this.tableLayoutPanel3.Controls.Add(this.tankmeter, 0, 0);
          this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
          this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
          this.tableLayoutPanel3.Name = "tableLayoutPanel3";
          this.tableLayoutPanel3.RowCount = 2;
          this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
          this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
          this.tableLayoutPanel3.Size = new System.Drawing.Size(194, 425);
          this.tableLayoutPanel3.TabIndex = 2;
          // 
          // tankrefresh
          // 
          this.tankrefresh.Location = new System.Drawing.Point(3, 393);
          this.tankrefresh.Name = "tankrefresh";
          this.tankrefresh.Size = new System.Drawing.Size(75, 23);
          this.tankrefresh.TabIndex = 2;
          this.tankrefresh.Text = "Refresh";
          this.tankrefresh.UseVisualStyleBackColor = true;
          this.tankrefresh.Click += new System.EventHandler(this.tankrefresh_Click);
          // 
          // tanktimer
          // 
          this.tanktimer.Enabled = true;
          this.tanktimer.Interval = 1000;
          this.tanktimer.Tick += new System.EventHandler(this.tanktimer_Tick);
          // 
          // feedTextToolStripMenuItem
          // 
          this.feedTextToolStripMenuItem.Name = "feedTextToolStripMenuItem";
          this.feedTextToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
          this.feedTextToolStripMenuItem.Text = "Feed text...";
          this.feedTextToolStripMenuItem.Click += new System.EventHandler(this.feedTextToolStripMenuItem_Click);
          // 
          // feedFileToolStripMenuItem
          // 
          this.feedFileToolStripMenuItem.Name = "feedFileToolStripMenuItem";
          this.feedFileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
          this.feedFileToolStripMenuItem.Text = "Feed file...";
          this.feedFileToolStripMenuItem.Click += new System.EventHandler(this.feedFileToolStripMenuItem_Click);
          // 
          // toolStripSeparator3
          // 
          this.toolStripSeparator3.Name = "toolStripSeparator3";
          this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
          // 
          // tankmeter
          // 
          this.tankmeter.Dock = System.Windows.Forms.DockStyle.Fill;
          this.tankmeter.Location = new System.Drawing.Point(3, 3);
          this.tankmeter.Name = "tankmeter";
          treeNode1.Name = "simple";
          treeNode1.Tag = "simple";
          treeNode1.Text = "Damage received / blocked";
          treeNode2.Name = "type";
          treeNode2.Tag = "type";
          treeNode2.Text = "Damage received by type";
          treeNode3.Name = "monster";
          treeNode3.Tag = "monster";
          treeNode3.Text = "Damage received by monster";
          this.tankmeter.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
          this.tankmeter.Size = new System.Drawing.Size(188, 384);
          this.tankmeter.TabIndex = 3;
          // 
          // MainWindow
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(877, 481);
          this.Controls.Add(this.maintabs);
          this.Controls.Add(this.mainmenu);
          this.MainMenuStrip = this.mainmenu;
          this.Name = "MainWindow";
          this.Text = "dclog - DDO Combat Log";
          this.Load += new System.EventHandler(this.MainWindow_Load);
          this.mainmenu.ResumeLayout(false);
          this.mainmenu.PerformLayout();
          this.maintabs.ResumeLayout(false);
          this.tabPage1.ResumeLayout(false);
          this.tabPage1.PerformLayout();
          this.tabPage2.ResumeLayout(false);
          this.tabPage2.PerformLayout();
          this.tabPage3.ResumeLayout(false);
          this.tableLayoutPanel1.ResumeLayout(false);
          this.groupBox1.ResumeLayout(false);
          this.groupBox1.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.dpschart)).EndInit();
          this.tabPage4.ResumeLayout(false);
          this.tableLayoutPanel2.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.tankchart)).EndInit();
          this.tableLayoutPanel3.ResumeLayout(false);
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainmenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attach;
        private System.Windows.Forms.TabControl maintabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox applog;
        private System.Windows.Forms.TextBox combatlog;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ststop;
        private System.Windows.Forms.Button ststart;
        private System.Windows.Forms.ComboBox sttarget;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart dpschart;
        private System.Windows.Forms.Label ststatus;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart tankchart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button tankrefresh;
        private System.Windows.Forms.Timer tanktimer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportABugToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem feedFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feedTextToolStripMenuItem;
        private System.Windows.Forms.TreeView tankmeter;
    }
}

