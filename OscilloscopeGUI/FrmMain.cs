// Author: Leonardo Tazzini

using System;
using System.Windows.Forms;

namespace OscilloscopeGUI
{
    /// <summary>
    /// Sample GUI for acquiring Normal / Long memory mode and Normal / Maximum Points mode
    /// </summary>
    public partial class FrmMain : Form
    {
        Oscilloscope _osc;
        GnuPlot _gnuplot = new GnuPlot();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            txtGnuPlotPath.Text = _gnuplot.Path;
            if (Oscilloscope.GetResources().Length==0)
            {
                MessageBox.Show("Please connect oscilloscope then click on Check");
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            _osc = new Oscilloscope(cbResources.Text);
        }

        private void btnSaveCSV_Click(object sender, EventArgs e)
        {
            _gnuplot.Path = txtGnuPlotPath.Text;

            _osc.Run();

            // Set up some settings on oscilloscope
            if (rbNormalPoints.Checked)
            {
                _osc.SetWaveformPointsMode(PointsMode.Normal);
            }
            else
            {
                _osc.SetWaveformPointsMode(PointsMode.Maximum);
            }

            // Memory depth
            if (rbNormal.Checked)
            {
                _osc.SetAcquireMemoryDepth(AcquireMemoryDepth.Normal);
            }
            else
            {
                _osc.SetAcquireMemoryDepth(AcquireMemoryDepth.Long);
            }

            _osc.SetTriggerSweep(TriggerSweep.Single);
            _osc.Stop();
            // Run and wait trigger
            _osc.Run();
            _osc.WaitTriggerStop();

            // Get Waveform and save it as CSV file
            string csvFileName = "data.csv";

            if (cbCh1.Checked && cbCh2.Checked)
            {
                _osc.GetWaveforms().SaveCSV(csvFileName);
                _gnuplot.DrawGraph(csvFileName, 2, rbOutPNG.Checked);
            }
            else
            {
                if (cbCh1.Checked)
                {
                    _osc.Channel1.GetWaveform().SaveCSV(csvFileName);
                    // Draw CSV file with GNU Plot      
                    _gnuplot.DrawGraph(csvFileName, 1, rbOutPNG.Checked);
                }
                else if (cbCh2.Checked)
                {
                    _osc.Channel2.GetWaveform().SaveCSV(csvFileName);
                    _gnuplot.DrawGraph(csvFileName, 1, rbOutPNG.Checked);
                }
                else
                {
                    // Nothing					
                }
            }

            // Release oscilloscope remote control
            _osc.Close();
        }

        private void UpdatePoints(object sender, EventArgs e)
        {
            int points = 0;

            if (!cbCh1.Checked && !cbCh2.Checked)
            {
                points = 0;
            }
            else
            {
                if (rbNormalPoints.Checked)
                {
                    points = 600;
                }
                else    // Max Points
                {
                    if (rbNormal.Checked)
                    {
                        if (cbCh1.Checked && cbCh2.Checked)
                        {
                            points = 8192;
                        }
                        else
                        {
                            points = 16384;
                        }
                    }
                    else
                    {
                        if (cbCh1.Checked && cbCh2.Checked)
                        {
                            points = 524288;
                        }
                        else
                        {
                            points = 1048576;
                        }
                    }
                }
            }
            lblPoints.Text = points.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbResources.Items.AddRange(Oscilloscope.GetResources());
            cbResources.SelectedIndex = cbResources.Items.Count - 1;
        }

    }
}
