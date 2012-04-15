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
  partial class FeedDialog
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.combatlog = new System.Windows.Forms.TextBox();
      this.okay = new System.Windows.Forms.Button();
      this.cancel = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.combatlog);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(634, 242);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Paste combat log here...";
      // 
      // combatlog
      // 
      this.combatlog.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.combatlog.Location = new System.Drawing.Point(6, 19);
      this.combatlog.Multiline = true;
      this.combatlog.Name = "combatlog";
      this.combatlog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.combatlog.Size = new System.Drawing.Size(622, 217);
      this.combatlog.TabIndex = 0;
      // 
      // okay
      // 
      this.okay.Location = new System.Drawing.Point(454, 261);
      this.okay.Name = "okay";
      this.okay.Size = new System.Drawing.Size(93, 27);
      this.okay.TabIndex = 1;
      this.okay.Text = "Okay";
      this.okay.UseVisualStyleBackColor = true;
      this.okay.Click += new System.EventHandler(this.okay_Click);
      // 
      // cancel
      // 
      this.cancel.Location = new System.Drawing.Point(553, 261);
      this.cancel.Name = "cancel";
      this.cancel.Size = new System.Drawing.Size(93, 27);
      this.cancel.TabIndex = 2;
      this.cancel.Text = "Cancel";
      this.cancel.UseVisualStyleBackColor = true;
      this.cancel.Click += new System.EventHandler(this.cancel_Click);
      // 
      // FeedDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancel;
      this.ClientSize = new System.Drawing.Size(658, 300);
      this.Controls.Add(this.cancel);
      this.Controls.Add(this.okay);
      this.Controls.Add(this.groupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FeedDialog";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Feed combat log to application...";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox combatlog;
    private System.Windows.Forms.Button okay;
    private System.Windows.Forms.Button cancel;
  }
}