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
          this.mainmenu = new System.Windows.Forms.MenuStrip();
          this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.attach = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
          this.feedFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.feedTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
          this.mainmenu.SuspendLayout();
          this.maintabs.SuspendLayout();
          this.tabPage1.SuspendLayout();
          this.tabPage2.SuspendLayout();
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
          this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
          this.fileToolStripMenuItem.Text = "File";
          // 
          // attach
          // 
          this.attach.Name = "attach";
          this.attach.Size = new System.Drawing.Size(144, 22);
          this.attach.Text = "Attach...";
          this.attach.Click += new System.EventHandler(this.attach_Click);
          // 
          // toolStripSeparator3
          // 
          this.toolStripSeparator3.Name = "toolStripSeparator3";
          this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
          // 
          // feedFileToolStripMenuItem
          // 
          this.feedFileToolStripMenuItem.Name = "feedFileToolStripMenuItem";
          this.feedFileToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
          this.feedFileToolStripMenuItem.Text = "Feed file...";
          this.feedFileToolStripMenuItem.Click += new System.EventHandler(this.feedFileToolStripMenuItem_Click);
          // 
          // feedTextToolStripMenuItem
          // 
          this.feedTextToolStripMenuItem.Name = "feedTextToolStripMenuItem";
          this.feedTextToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
          this.feedTextToolStripMenuItem.Text = "Feed text...";
          this.feedTextToolStripMenuItem.Click += new System.EventHandler(this.feedTextToolStripMenuItem_Click);
          // 
          // toolStripSeparator1
          // 
          this.toolStripSeparator1.Name = "toolStripSeparator1";
          this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
          // 
          // quitToolStripMenuItem
          // 
          this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
          this.quitToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
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
          this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
          this.helpToolStripMenuItem.Text = "Help";
          // 
          // reportABugToolStripMenuItem
          // 
          this.reportABugToolStripMenuItem.Name = "reportABugToolStripMenuItem";
          this.reportABugToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
          this.reportABugToolStripMenuItem.Text = "Report a bug";
          this.reportABugToolStripMenuItem.Click += new System.EventHandler(this.reportABugToolStripMenuItem_Click);
          // 
          // toolStripSeparator2
          // 
          this.toolStripSeparator2.Name = "toolStripSeparator2";
          this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
          // 
          // aboutToolStripMenuItem
          // 
          this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
          this.aboutToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
          this.aboutToolStripMenuItem.Text = "About";
          this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
          // 
          // maintabs
          // 
          this.maintabs.Controls.Add(this.tabPage1);
          this.maintabs.Controls.Add(this.tabPage2);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportABugToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem feedFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feedTextToolStripMenuItem;
    }
}

