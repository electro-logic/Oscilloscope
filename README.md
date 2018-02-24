# C# Rigol Oscilloscope Library and GUI

This project allow to control oscilloscope and acquire up to 1M of data points from oscilloscope and analyze it with pc
instead that directly with Rigol touchscreen display that can be difficult and time-consuming.

This project is born as an auxiliary project for an university exam, code could not be of production-quality. Updated to NI-VISA 17.5 before sharing to support Windows 10.

OscilloscopeLib is a library for handling Rigol's Oscilloscopes (tested only with DS1102E)
OscilloscopeCLI is a command line sample usage of OscilloscopeLib
OscilloscopeGUI is an app with a GUI that allow easy data acquisition and display
OscilloscopeTest contains Unit Tests for easily checking if your own oscilloscope model is compliant with library

Screenshot of OscilloscopeGUI

![alt text](https://raw.githubusercontent.com/electro-logic/Oscilloscope/master/Docs/gui.png)

# Example of usage

Raw data from an encoder

![alt text](https://raw.githubusercontent.com/electro-logic/Oscilloscope/master/Docs/oscilloscope.png)

Data acquired and processed with the aid of this library and a graph of velocity produced with very little code

![alt text](https://raw.githubusercontent.com/electro-logic/Oscilloscope/master/Docs/speed_graph.png)

# Dependencies:

NI-VISA Run-Time Engine 17.5
http://www.ni.com/download/ni-visa-run-time-engine/7222/en/

NI-VISA SDK 17.5 
http://www.ni.com/download/ni-visa-17.5/7220/en/

Gnuplot (for graphs)
http://www.gnuplot.info/