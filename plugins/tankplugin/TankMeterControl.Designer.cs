namespace DCLog.DPSPlugin
{
  partial class TankMeterControl
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Damage received / blocked");
      System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Damage received by type");
      System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Damage received by monster");
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      this.tankrefresh = new System.Windows.Forms.Button();
      this.tankmeter = new System.Windows.Forms.TreeView();
      this.tankchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.tanktimer = new System.Windows.Forms.Timer(this.components);
      this.tableLayoutPanel2.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tankchart)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.tankchart, 1, 0);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(777, 451);
      this.tableLayoutPanel2.TabIndex = 1;
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
      this.tableLayoutPanel3.Size = new System.Drawing.Size(194, 445);
      this.tableLayoutPanel3.TabIndex = 2;
      // 
      // tankrefresh
      // 
      this.tankrefresh.Location = new System.Drawing.Point(3, 413);
      this.tankrefresh.Name = "tankrefresh";
      this.tankrefresh.Size = new System.Drawing.Size(75, 23);
      this.tankrefresh.TabIndex = 2;
      this.tankrefresh.Text = "Refresh";
      this.tankrefresh.UseVisualStyleBackColor = true;
      this.tankrefresh.Click += new System.EventHandler(this.tankrefresh_Click);
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
      this.tankmeter.Size = new System.Drawing.Size(188, 404);
      this.tankmeter.TabIndex = 3;
      this.tankmeter.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tankmeter_AfterSelect);
      // 
      // tankchart
      // 
      chartArea1.Name = "ChartArea1";
      this.tankchart.ChartAreas.Add(chartArea1);
      this.tankchart.Dock = System.Windows.Forms.DockStyle.Fill;
      legend1.Name = "Legend1";
      this.tankchart.Legends.Add(legend1);
      this.tankchart.Location = new System.Drawing.Point(203, 3);
      this.tankchart.Name = "tankchart";
      series1.ChartArea = "ChartArea1";
      series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
      series1.Legend = "Legend1";
      series1.Name = "Series1";
      series1.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.No;
      this.tankchart.Series.Add(series1);
      this.tankchart.Size = new System.Drawing.Size(571, 445);
      this.tankchart.TabIndex = 1;
      this.tankchart.Text = "Tank Chart";
      // 
      // tanktimer
      // 
      this.tanktimer.Enabled = true;
      this.tanktimer.Interval = 1000;
      this.tanktimer.Tick += new System.EventHandler(this.tanktimer_Tick);
      // 
      // TankMeterControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Window;
      this.Controls.Add(this.tableLayoutPanel2);
      this.Name = "TankMeterControl";
      this.Size = new System.Drawing.Size(777, 451);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.tankchart)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    private System.Windows.Forms.Button tankrefresh;
    private System.Windows.Forms.TreeView tankmeter;
    private System.Windows.Forms.DataVisualization.Charting.Chart tankchart;
    private System.Windows.Forms.Timer tanktimer;
  }
}
