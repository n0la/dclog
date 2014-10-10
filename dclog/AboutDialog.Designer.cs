namespace dclog
{
  partial class AboutDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.About = new System.Windows.Forms.TabPage();
      this.label6 = new System.Windows.Forms.Label();
      this.projectsite = new System.Windows.Forms.LinkLabel();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.gpl = new System.Windows.Forms.TextBox();
      this.tabControl1.SuspendLayout();
      this.About.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.About);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(557, 341);
      this.tabControl1.TabIndex = 0;
      // 
      // About
      // 
      this.About.Controls.Add(this.label6);
      this.About.Controls.Add(this.projectsite);
      this.About.Controls.Add(this.label5);
      this.About.Controls.Add(this.label4);
      this.About.Controls.Add(this.label3);
      this.About.Controls.Add(this.label2);
      this.About.Controls.Add(this.label1);
      this.About.Location = new System.Drawing.Point(4, 22);
      this.About.Name = "About";
      this.About.Padding = new System.Windows.Forms.Padding(3);
      this.About.Size = new System.Drawing.Size(549, 315);
      this.About.TabIndex = 0;
      this.About.Text = "About";
      this.About.UseVisualStyleBackColor = true;
      // 
      // label6
      // 
      this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(14, 74);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(527, 22);
      this.label6.TabIndex = 7;
      this.label6.Text = "Copyright 2012 by Florian Stinglmayr, et.al. See COPYRIGHTS for further informati" +
    "on.";
      // 
      // projectsite
      // 
      this.projectsite.AutoSize = true;
      this.projectsite.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.projectsite.Location = new System.Drawing.Point(169, 277);
      this.projectsite.Name = "projectsite";
      this.projectsite.Size = new System.Drawing.Size(210, 14);
      this.projectsite.TabIndex = 6;
      this.projectsite.TabStop = true;
      this.projectsite.Text = "https://github.com/n0la/dclog";
      this.projectsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(136, 19);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(276, 16);
      this.label5.TabIndex = 5;
      this.label5.Text = "\"May the goddess keep us from single vision.\"";
      // 
      // label4
      // 
      this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(11, 163);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(530, 91);
      this.label4.TabIndex = 3;
      this.label4.Text = resources.GetString("label4.Text");
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.ForeColor = System.Drawing.Color.Black;
      this.label3.Location = new System.Drawing.Point(8, 54);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(164, 16);
      this.label3.TabIndex = 2;
      this.label3.Text = "DCLog - Version 0.3 Beta";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.Red;
      this.label2.Location = new System.Drawing.Point(8, 143);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(66, 16);
      this.label2.TabIndex = 1;
      this.label2.Text = "Warning!";
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(14, 93);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(527, 37);
      this.label1.TabIndex = 0;
      this.label1.Text = "An application to view and analyze combat log created by the MMORPG Dungeons and " +
    "Dragons: Online.";
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.gpl);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(549, 315);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "License";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // gpl
      // 
      this.gpl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gpl.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.gpl.Location = new System.Drawing.Point(3, 3);
      this.gpl.Multiline = true;
      this.gpl.Name = "gpl";
      this.gpl.ReadOnly = true;
      this.gpl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.gpl.Size = new System.Drawing.Size(543, 309);
      this.gpl.TabIndex = 0;
      this.gpl.Text = resources.GetString("gpl.Text");
      // 
      // AboutDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(557, 341);
      this.Controls.Add(this.tabControl1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "AboutDialog";
      this.Text = "About...";
      this.tabControl1.ResumeLayout(false);
      this.About.ResumeLayout(false);
      this.About.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage About;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.LinkLabel projectsite;
    private System.Windows.Forms.TextBox gpl;
    private System.Windows.Forms.Label label6;
  }
}