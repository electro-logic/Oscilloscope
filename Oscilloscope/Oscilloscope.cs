// Author: Leonardo Tazzini

using NationalInstruments.Visa;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

/// <summary>
/// Handle Rigol's Oscilloscopes like model DS1102E
/// </summary>
public partial class Oscilloscope
{

    // TODO: Implement IDisposable for closing resources and releasing oscilloscope remote control (Close call)?

    string _model;
    string _serialNumber;
    string _swVersion;
    Channel[] _channels;
    uint _numChannels;     // 2 Channel models like DS1102E

    static MessageBasedSession _mbSession;
    static ResourceManager _resManager = new ResourceManager();

    // TODO: Move in VisaHelper file
    public static string[] GetResources()
    {
        string[] results = new string[] { };

        try
        {
            results = _resManager.Find("?*").ToArray();
        }
        catch (Exception)
        {
        }

        return results;
    }

    public Oscilloscope(string resource = "USB?*DS1E?*INSTR", uint channels = 2)
    {
        // TODO: check if channels is valid

        _numChannels = channels;
        _channels = new Channel[_numChannels];

        // Create Message based session, open first resource found
        _mbSession = (MessageBasedSession)_resManager.Open(_resManager.Find(resource).First());
        _mbSession.TimeoutMilliseconds = 1000 * 60 * 5;
        
        // Create channel object for every physical channel of oscilloscope
        for (uint i = 0; i < _numChannels; i++)
        {
            _channels[i] = new Channel(i + 1, this);
        }

        Write("*IDN?");
        // Example response: Rigol Technologies,DS1102E,DS1EB1XXXXXXXX,00.02.06.00.01
        string[] fields = ReadString().Split(',');
        _model = fields[1];
        _serialNumber = fields[2];
        _swVersion = fields[3];
    }

    public Channel[] Channels
    {
        get { return _channels; }
        set { _channels = value; }
    }

    public Channel Channel1
    {
        get { return _channels[0]; }
    }

    public Channel Channel2
    {
        get { return _channels[1]; }
    }

    /// <summary>
    /// Return Waveforms of Channel1 and Channel2
    public WaveForm GetWaveforms()
    {
        // TODO: Improve for 4 channel model
        WaveForm wave1 = Channel1.GetWaveform();
        WaveForm wave2 = Channel2.GetWaveform();
        return new WaveForm(wave1.Times, new List<double[]>() { wave1.Values[0], wave2.Values[0] });
    }

    public string Model
    {
        get { return _model; }
    }

    public string SerialNumber
    {
        get { return _serialNumber; }
    }

    public string SwVersion
    {
        get { return _swVersion; }
    }

    public void Write(string str)
    {
        _mbSession.RawIO.Write(str);
        // Give time to process command
        Thread.Sleep(50);
        // TODO: Improve and validate
    }

    public string ReadString()
    {
        return _mbSession.RawIO.ReadString();
    }

    public byte[] Read()
    {
        // Rigol DS1102E Long Memory can acquire 1M points (1048576 bytes + 10 bytes header)            
        var readBytes = _mbSession.RawIO.Read(1048586, out var status);
        Debug.WriteLine(string.Format("Readed {0} bytes from device with Status {1}", readBytes.Length, status));
        return readBytes;
    }

    /// <summary>
    /// Wait until Trigger Status is Stop
    /// </summary>
    /// <remarks>
    /// Poll every 50ms
    /// </remarks>
    public void WaitTriggerStop()
    {
        while (GetTriggerStatus() != TriggerStatus.Stop)
        {
            Thread.Sleep(50);
        }
    }

    // See OscilloscopeCommands for commands like Run, Stop, Get/Set Property, etc..

}