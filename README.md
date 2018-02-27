# Oscilloscope Library and GUI for Rigol in C#

This project allow to remote control your oscilloscope, setup parameters and acquire data points. 

You can save and analyze it with pc instead that with Rigol device that can be limited, difficult and time-consuming, just connect your oscilloscope with USB to computer.

## Projects

- OscilloscopeLib is a, object-oriented library for handling Rigol's Oscilloscopes (tested only with DS1102E)

- OscilloscopeCLI is a command line sample usage of OscilloscopeLib

- OscilloscopeGUI is an app with a GUI that allow easy data acquisition and display

- OscilloscopeTest contains Unit Tests for easily checking if your own oscilloscope model is compliant with library

## Compiled Software

You can download compiled software here:

v1.0:	https://github.com/electro-logic/Oscilloscope/blob/master/Binaries/Oscilloscope_1_0.zip?raw=true

You need to install NI-VISA Run-Time Engine 17.5 (120 MB) to run the software

http://www.ni.com/download/ni-visa-run-time-engine/7222/en/

See notes for informations about Gnuplot (needed to generate graphs)

## Screenshoots

![alt text](https://raw.githubusercontent.com/electro-logic/Oscilloscope/master/Docs/gui.png)

*OscilloscopeGUI*

![alt text](https://raw.githubusercontent.com/electro-logic/Oscilloscope/master/Docs/gnuplot.png)

*Automatically generated Gnuplot graph (zoomable)*


## Example of usage

To configure and acquire data you can write code like the following:

```
// 1M data point acquisition
void LongMemoryAcquisitionExample()
{
    var rigol = new Oscilloscope();
    rigol.Run();
    rigol.SetWaveformPointsMode(PointsMode.Maximum);
    rigol.SetAcquireMemoryDepth(AcquireMemoryDepth.Long);
    rigol.SetTriggerSweep(TriggerSweep.Single);
    rigol.WaitTriggerStop();
    rigol.Stop();
    var wave = rigol.Channel1.GetWaveform();
    wave.SaveCSV(csvFileName);
    rigol.Close();
}
```

Then you can graph your acquired data with Excel or automatically with GnuPlot

```
// Display acquired data with Excel (or any other installed software that can handle CSV)
Process.Start(csvFileName);

// Draw a graph with GNU Plot and save it in out.png
GnuPlot gnuPlot = new GnuPlot();
gnuPlot.DrawGraph(csvFileName, 1);   // only channel 1
```

## Notes

This project is born as an auxiliary project so code could not be of production-quality. If there is interest I can improve it, anyway any contribution is welcome.

I have initially written this library in 2014 to check the velocity profile of a stepper motor with a real-time driver that I have implemented.

Now I think that this project can be useful to others that own a RIgol oscilloscope so I have released it with updated NI-VISA 17.5 to support Windows 10.


Here are some images to better understand what this library allow you to do with very little work.


![alt text](https://raw.githubusercontent.com/electro-logic/Oscilloscope/master/Docs/oscilloscope.png)

*Oscilloscope display*


![alt text](https://raw.githubusercontent.com/electro-logic/Oscilloscope/master/Docs/speed_graph.png)

*Data acquired and processed with the aid of this library and a graph of velocity of the system produced*


You can also write some code with C# to post-process CSV data and extrapolate relevant information for your application (ex. I used it to get velocity profile of my system from the waveform of a revolution detector).


## Dependencies

Rigol oscilloscope support Virtual Instrument Software Architecture (VISA) standard for configuring, programming, and troubleshooting instrumentation systems. 

Graphs are generated with Gnuplot software to avoid reinventing the wheel. Data can be analyzed and graphed also with Excel or any software that can open CSV files.


NI-VISA SDK 17.5 (for compiling code)

http://www.ni.com/download/ni-visa-17.5/7220/en/


Rigol Documentation

https://www.rigol.eu/products/digital-oscilloscopes/1000/


Gnuplot 5.2 (for graphs, optional)

http://www.gnuplot.info/

**NB:** Gnuplot keyboard commands to interact with graph are available at Gnuplot command line (just launch gnuplot.exe from Start) with the command "show bind", here are reported some:

- a		autoscale
- \+	zoom in
- \-	zoom out

Right click with the mouse to zoom a section of the graph

*Warning:* Graph with 1M points can be slow to display and interact