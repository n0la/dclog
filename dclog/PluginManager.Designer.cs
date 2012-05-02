namespace dclog
{
  partial class PluginManager
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
      System.Windows.Forms.ColumnHeader columnHeader1;
      System.Windows.Forms.ColumnHeader Name;
      System.Windows.Forms.ColumnHeader columnHeader2;
      System.Windows.Forms.ColumnHeader columnHeader3;
      this.label1 = new System.Windows.Forms.Label();
      this.plist = new System.Windows.Forms.ListView();
      this.okay = new System.Windows.Forms.Button();
      this.cancel = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(13, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(410, 34);
      this.label1.TabIndex = 0;
      this.label1.Text = "This is a list of available plugins. Uncheck or check the box near the plugin to " +
          "disable/enable a plugin. Any changes here require the application to be restarte" +
          "d.";
      // 
      // plist
      // 
      this.plist.CheckBoxes = true;
      this.plist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1,
            Name,
            columnHeader2,
            columnHeader3});
      this.plist.FullRowSelect = true;
      this.plist.GridLines = true;
      this.plist.Location = new System.Drawing.Point(16, 51);
      this.plist.Name = "plist";
      this.plist.Size = new System.Drawing.Size(407, 179);
      this.plist.TabIndex = 1;
      this.plist.UseCompatibleStateImageBehavior = false;
      this.plist.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      columnHeader1.Text = "";
      columnHeader1.Width = 30;
      // 
      // Name
      // 
      Name.Text = "Name";
      Name.Width = 90;
      // 
      // columnHeader2
      // 
      columnHeader2.Text = "Description";
      columnHeader2.Width = 210;
      // 
      // columnHeader3
      // 
      columnHeader3.Text = "Version";
      // 
      // okay
      // 
      this.okay.Location = new System.Drawing.Point(261, 236);
      this.okay.Name = "okay";
      this.okay.Size = new System.Drawing.Size(78, 25);
      this.okay.TabIndex = 2;
      this.okay.Text = "Ok";
      this.okay.UseVisualStyleBackColor = true;
      this.okay.Click += new System.EventHandler(this.okay_Click);
      // 
      // cancel
      // 
      this.cancel.Location = new System.Drawing.Point(345, 236);
      this.cancel.Name = "cancel";
      this.cancel.Size = new System.Drawing.Size(78, 25);
      this.cancel.TabIndex = 3;
      this.cancel.Text = "Cancel";
      this.cancel.UseVisualStyleBackColor = true;
      this.cancel.Click += new System.EventHandler(this.cancel_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(16, 236);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(130, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "red = Plugin is out of date.";
      // 
      // PluginManager
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(435, 274);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cancel);
      this.Controls.Add(this.okay);
      this.Controls.Add(this.plist);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "PluginManager";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Plugins";
      this.Load += new System.EventHandler(this.PluginManager_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListView plist;
    private System.Windows.Forms.Button okay;
    private System.Windows.Forms.Button cancel;
    private System.Windows.Forms.Label label2;
  }
}