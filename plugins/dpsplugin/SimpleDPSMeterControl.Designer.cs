﻿namespace DCLog.DPSPlugin
{
  partial class SimpleDPSMeterControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.ststatus = new System.Windows.Forms.Label();
      this.ststop = new System.Windows.Forms.Button();
      this.ststart = new System.Windows.Forms.Button();
      this.sttarget = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.dpschart = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.tableLayoutPanel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dpschart)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
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
      this.tableLayoutPanel1.Size = new System.Drawing.Size(877, 454);
      this.tableLayoutPanel1.TabIndex = 4;
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
      chartArea3.AxisX.Title = "Seconds";
      chartArea3.AxisY.Title = "DPS";
      chartArea3.Name = "ChartArea1";
      this.dpschart.ChartAreas.Add(chartArea3);
      this.dpschart.Dock = System.Windows.Forms.DockStyle.Fill;
      legend3.Name = "Legend1";
      this.dpschart.Legends.Add(legend3);
      this.dpschart.Location = new System.Drawing.Point(3, 113);
      this.dpschart.Name = "dpschart";
      series3.ChartArea = "ChartArea1";
      series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
      series3.Legend = "Legend1";
      series3.Name = "DPS";
      this.dpschart.Series.Add(series3);
      this.dpschart.Size = new System.Drawing.Size(871, 338);
      this.dpschart.TabIndex = 4;
      this.dpschart.Text = "Single Target DPS";
      // 
      // SimpleDPSMeterControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "SimpleDPSMeterControl";
      this.Size = new System.Drawing.Size(877, 454);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dpschart)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label ststatus;
    private System.Windows.Forms.Button ststop;
    private System.Windows.Forms.Button ststart;
    private System.Windows.Forms.ComboBox sttarget;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DataVisualization.Charting.Chart dpschart;
  }
}