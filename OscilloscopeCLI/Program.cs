// Author: Leonardo Tazzini

using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;

namespace OscilloscopeCLI
{
    class Program
    {
        static string csvFileName = "data.csv";

        // Sample usage of Oscilloscope library
        static void Main(string[] args)
        {
            // Decimal separator is '.'
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            /*
            LongMemoryAcquisitionExample();

            // Display acquired data
            Process.Start(csvFileName);

            // Draw CSV file with GNU Plot      
            GnuPlot gnuPlot = new GnuPlot();    // NB: change path of gnuplot.exe with alternative constructor
            gnuPlot.DrawGraph(csvFileName, 1);
            */

            OscilloscopePromptExample();
        }

        // 1M data point acquisition
        static void LongMemoryAcquisitionExample()
        {
            var rigol = new Oscilloscope();
            rigol.Run();
            rigol.SetWaveformPointsMode(PointsMode.Maximum);
            rigol.SetAcquireMemoryDepth(AcquireMemoryDepth.Long);
            rigol.SetTriggerSweep(TriggerSweep.Single);
            rigol.WaitTriggerStop();
            rigol.Stop();
            WaveForm wave = rigol.Channel1.GetWaveform();
            wave.SaveCSV(csvFileName);
            rigol.Close();
        }

        /// <summary>
        /// Simple Command Line Prompt for Rigol oscilloscope
        /// </summary>
        static void OscilloscopePromptExample()
        {
            Console.WriteLine("Oscilloscope Command Prompt");
            Console.WriteLine("Please choose an instrument by typing the index");
            Console.WriteLine("Instruments:");
            string[] resources = Oscilloscope.GetResources();
            for (int i = 0; i < resources.Length; i++)
            {
                Console.WriteLine("[" + i.ToString() + "]: " + resources[i]);
            }

            int resIndex;

            menu:
            if (!int.TryParse(Console.ReadLine().Trim(), out resIndex))
            {
                Console.WriteLine("Please an choose instrument");
                goto menu;
            }

            Console.WriteLine("Example commands:");
            Console.WriteLine("*IDN?");            
            Console.WriteLine(":WAVeform:POINts:MODE NORMAL|MAXIMUM|RAW");
            Console.WriteLine(":ACQuire:MEMDepth NORMAL|LONG");
            Console.WriteLine(":TRIGger:EDGE:SWEep SINGLE|NORMAL|AUTO");
            Console.WriteLine(":TRIGger:STATus?");
            Console.WriteLine(":RUN");            
            Console.WriteLine(":STOP");
            Console.WriteLine(":WAVEFORM:DATA? CHAN1");
            Console.WriteLine("quit");

            // Create instance of Oscilloscope class and stop any acquisition
            Oscilloscope rigol = new Oscilloscope(resources[resIndex]);
            while (true)
            {
                try
                {
                    Console.Write(">");
                    string cmd = Console.ReadLine();
                    if (cmd == "quit")
                        break;
                    rigol.Write(cmd);
                    if (cmd.StartsWith(":WAVEFORM:DATA?"))
                    {
                        var bytes = rigol.Read();
                        Console.WriteLine($"{bytes.Length} bytes received");
                        //if (bytes.Length > 0)
                        //{
                        //    var sb = new StringBuilder();
                        //    foreach (byte b in bytes)
                        //    {
                        //        sb.Append($"{b.ToString("X2")}-");
                        //    }
                        //    sb.Remove(sb.Length - 1, 1);
                        //    Console.WriteLine(sb.ToString());
                        //}
                    }
                    else if (cmd.Contains("?"))
                    {
                        Console.WriteLine(rigol.ReadString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            rigol.Close();
        }

    }
}