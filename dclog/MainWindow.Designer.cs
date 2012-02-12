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
          System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
          System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
          System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
          this.menuStrip1 = new System.Windows.Forms.MenuStrip();
          this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.attach = new System.Windows.Forms.ToolStripMenuItem();
          this.maintabs = new System.Windows.Forms.TabControl();
          this.tabPage1 = new System.Windows.Forms.TabPage();
          this.applog = new System.Windows.Forms.TextBox();
          this.tabPage2 = new System.Windows.Forms.TabPage();
          this.combatlog = new System.Windows.Forms.TextBox();
          this.tabPage3 = new System.Windows.Forms.TabPage();
          this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
          this.groupBox1 = new System.Windows.Forms.GroupBox();
          this.ststop = new System.Windows.Forms.Button();
          this.ststart = new System.Windows.Forms.Button();
          this.sttarget = new System.Windows.Forms.ComboBox();
          this.label1 = new System.Windows.Forms.Label();
          this.dpschart = new System.Windows.Forms.DataVisualization.Charting.Chart();
          this.ststatus = new System.Windows.Forms.Label();
          this.menuStrip1.SuspendLayout();
          this.maintabs.SuspendLayout();
          this.tabPage1.SuspendLayout();
          this.tabPage2.SuspendLayout();
          this.tabPage3.SuspendLayout();
          this.tableLayoutPanel1.SuspendLayout();
          this.groupBox1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.dpschart)).BeginInit();
          this.SuspendLayout();
          // 
          // menuStrip1
          // 
          this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
          this.menuStrip1.Location = new System.Drawing.Point(0, 0);
          this.menuStrip1.Name = "menuStrip1";
          this.menuStrip1.Size = new System.Drawing.Size(877, 24);
          this.menuStrip1.TabIndex = 0;
          this.menuStrip1.Text = "menuStrip1";
          // 
          // fileToolStripMenuItem
          // 
          this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.attach});
          this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
          this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
          this.fileToolStripMenuItem.Text = "File";
          // 
          // attach
          // 
          this.attach.Name = "attach";
          this.attach.Size = new System.Drawing.Size(118, 22);
          this.attach.Text = "Attach...";
          this.attach.Click += new System.EventHandler(this.attach_Click);
          // 
          // maintabs
          // 
          this.maintabs.Controls.Add(this.tabPage1);
          this.maintabs.Controls.Add(this.tabPage2);
          this.maintabs.Controls.Add(this.tabPage3);
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
          this.dpschart.Size = new System.Drawing.Size(863, 315);
          this.dpschart.TabIndex = 4;
          this.dpschart.Text = "Single Target DPS";
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
          // MainWindow
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(877, 481);
          this.Controls.Add(this.maintabs);
          this.Controls.Add(this.menuStrip1);
          this.MainMenuStrip = this.menuStrip1;
          this.Name = "MainWindow";
          this.Text = "dclog - DDO Combat Log";
          this.Load += new System.EventHandler(this.MainWindow_Load);
          this.menuStrip1.ResumeLayout(false);
          this.menuStrip1.PerformLayout();
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
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
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
    }
}

