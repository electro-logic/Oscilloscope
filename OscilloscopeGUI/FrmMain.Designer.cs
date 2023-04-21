namespace OscilloscopeGUI
{
  partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.cbResources = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPoints = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbLong = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbMaxPoints = new System.Windows.Forms.RadioButton();
            this.rbNormalPoints = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCh2 = new System.Windows.Forms.CheckBox();
            this.cbCh1 = new System.Windows.Forms.CheckBox();
            this.btnSaveCSV = new System.Windows.Forms.Button();
            this.rbOutGnuPlot = new System.Windows.Forms.RadioButton();
            this.rbOutPNG = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRefreshDevices = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGnuPlotPath = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbResources
            // 
            this.cbResources.FormattingEnabled = true;
            this.cbResources.Location = new System.Drawing.Point(18, 18);
            this.cbResources.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbResources.Name = "cbResources";
            this.cbResources.Size = new System.Drawing.Size(298, 28);
            this.cbResources.TabIndex = 99;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(18, 63);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(420, 35);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "&Connect to selected device";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPoints);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.rbMaxPoints);
            this.groupBox1.Controls.Add(this.rbNormalPoints);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbCh2);
            this.groupBox1.Controls.Add(this.cbCh1);
            this.groupBox1.Location = new System.Drawing.Point(18, 109);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(420, 209);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acquisition";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Location = new System.Drawing.Point(138, 171);
            this.lblPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(36, 20);
            this.lblPoints.TabIndex = 23;
            this.lblPoints.Text = "600";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 171);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Points";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbLong);
            this.panel1.Controls.Add(this.rbNormal);
            this.panel1.Location = new System.Drawing.Point(142, 71);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 37);
            this.panel1.TabIndex = 21;
            // 
            // rbLong
            // 
            this.rbLong.AutoSize = true;
            this.rbLong.Location = new System.Drawing.Point(120, 2);
            this.rbLong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbLong.Name = "rbLong";
            this.rbLong.Size = new System.Drawing.Size(63, 24);
            this.rbLong.TabIndex = 15;
            this.rbLong.Text = "Long";
            this.rbLong.UseVisualStyleBackColor = true;
            this.rbLong.CheckedChanged += new System.EventHandler(this.UpdatePoints);
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Checked = true;
            this.rbNormal.Location = new System.Drawing.Point(0, 2);
            this.rbNormal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(77, 24);
            this.rbNormal.TabIndex = 12;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "Normal";
            this.rbNormal.UseVisualStyleBackColor = true;
            this.rbNormal.CheckedChanged += new System.EventHandler(this.UpdatePoints);
            // 
            // rbMaxPoints
            // 
            this.rbMaxPoints.AutoSize = true;
            this.rbMaxPoints.Location = new System.Drawing.Point(262, 108);
            this.rbMaxPoints.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbMaxPoints.Name = "rbMaxPoints";
            this.rbMaxPoints.Size = new System.Drawing.Size(94, 24);
            this.rbMaxPoints.TabIndex = 20;
            this.rbMaxPoints.Text = "Maximum";
            this.rbMaxPoints.UseVisualStyleBackColor = true;
            this.rbMaxPoints.CheckedChanged += new System.EventHandler(this.UpdatePoints);
            // 
            // rbNormalPoints
            // 
            this.rbNormalPoints.AutoSize = true;
            this.rbNormalPoints.Checked = true;
            this.rbNormalPoints.Location = new System.Drawing.Point(142, 108);
            this.rbNormalPoints.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbNormalPoints.Name = "rbNormalPoints";
            this.rbNormalPoints.Size = new System.Drawing.Size(77, 24);
            this.rbNormalPoints.TabIndex = 19;
            this.rbNormalPoints.TabStop = true;
            this.rbNormalPoints.Text = "Normal";
            this.rbNormalPoints.UseVisualStyleBackColor = true;
            this.rbNormalPoints.CheckedChanged += new System.EventHandler(this.UpdatePoints);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Points Mode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Memory depth";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Channels";
            // 
            // cbCh2
            // 
            this.cbCh2.AutoSize = true;
            this.cbCh2.Location = new System.Drawing.Point(262, 37);
            this.cbCh2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCh2.Name = "cbCh2";
            this.cbCh2.Size = new System.Drawing.Size(100, 24);
            this.cbCh2.TabIndex = 14;
            this.cbCh2.Text = "Channel 2";
            this.cbCh2.UseVisualStyleBackColor = true;
            this.cbCh2.CheckedChanged += new System.EventHandler(this.UpdatePoints);
            // 
            // cbCh1
            // 
            this.cbCh1.AutoSize = true;
            this.cbCh1.Checked = true;
            this.cbCh1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCh1.Location = new System.Drawing.Point(142, 37);
            this.cbCh1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCh1.Name = "cbCh1";
            this.cbCh1.Size = new System.Drawing.Size(100, 24);
            this.cbCh1.TabIndex = 13;
            this.cbCh1.Text = "Channel 1";
            this.cbCh1.UseVisualStyleBackColor = true;
            this.cbCh1.CheckedChanged += new System.EventHandler(this.UpdatePoints);
            // 
            // btnSaveCSV
            // 
            this.btnSaveCSV.Location = new System.Drawing.Point(18, 422);
            this.btnSaveCSV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveCSV.Name = "btnSaveCSV";
            this.btnSaveCSV.Size = new System.Drawing.Size(420, 35);
            this.btnSaveCSV.TabIndex = 100;
            this.btnSaveCSV.Text = "&Save CSV and output";
            this.btnSaveCSV.UseVisualStyleBackColor = true;
            this.btnSaveCSV.Click += new System.EventHandler(this.btnSaveCSV_Click);
            // 
            // rbOutGnuPlot
            // 
            this.rbOutGnuPlot.AutoSize = true;
            this.rbOutGnuPlot.Location = new System.Drawing.Point(160, 386);
            this.rbOutGnuPlot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbOutGnuPlot.Name = "rbOutGnuPlot";
            this.rbOutGnuPlot.Size = new System.Drawing.Size(85, 24);
            this.rbOutGnuPlot.TabIndex = 101;
            this.rbOutGnuPlot.Text = "GnuPlot";
            this.rbOutGnuPlot.UseVisualStyleBackColor = true;
            // 
            // rbOutPNG
            // 
            this.rbOutPNG.AutoSize = true;
            this.rbOutPNG.Checked = true;
            this.rbOutPNG.Location = new System.Drawing.Point(280, 386);
            this.rbOutPNG.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbOutPNG.Name = "rbOutPNG";
            this.rbOutPNG.Size = new System.Drawing.Size(110, 24);
            this.rbOutPNG.TabIndex = 102;
            this.rbOutPNG.TabStop = true;
            this.rbOutPNG.Text = "PNG Image";
            this.rbOutPNG.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(88, 386);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 103;
            this.label6.Text = "Output";
            // 
            // btnRefreshDevices
            // 
            this.btnRefreshDevices.Location = new System.Drawing.Point(326, 14);
            this.btnRefreshDevices.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefreshDevices.Name = "btnRefreshDevices";
            this.btnRefreshDevices.Size = new System.Drawing.Size(112, 35);
            this.btnRefreshDevices.TabIndex = 104;
            this.btnRefreshDevices.Text = "&Refresh";
            this.btnRefreshDevices.UseVisualStyleBackColor = true;
            this.btnRefreshDevices.Click += new System.EventHandler(this.btnRefreshDevices_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 338);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 105;
            this.label3.Text = "GnuPlot Path";
            // 
            // txtGnuPlotPath
            // 
            this.txtGnuPlotPath.Location = new System.Drawing.Point(135, 334);
            this.txtGnuPlotPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGnuPlotPath.Name = "txtGnuPlotPath";
            this.txtGnuPlotPath.Size = new System.Drawing.Size(303, 26);
            this.txtGnuPlotPath.TabIndex = 106;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 474);
            this.Controls.Add(this.txtGnuPlotPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRefreshDevices);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rbOutPNG);
            this.Controls.Add(this.rbOutGnuPlot);
            this.Controls.Add(this.btnSaveCSV);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cbResources);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oscilloscope GUI v1.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox cbResources;
		private System.Windows.Forms.Button btnConnect;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox cbCh2;
    private System.Windows.Forms.CheckBox cbCh1;
		private System.Windows.Forms.RadioButton rbMaxPoints;
		private System.Windows.Forms.RadioButton rbNormalPoints;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton rbLong;
		private System.Windows.Forms.RadioButton rbNormal;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblPoints;
		private System.Windows.Forms.Button btnSaveCSV;
		private System.Windows.Forms.RadioButton rbOutGnuPlot;
		private System.Windows.Forms.RadioButton rbOutPNG;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnRefreshDevices;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtGnuPlotPath;
  }
}

