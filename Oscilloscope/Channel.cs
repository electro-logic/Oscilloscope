// Author: Leonardo Tazzini

/// <summary>
/// Represent an Oscilloscope Channel
/// </summary>
public class Channel
{
    uint _channelID;
    Oscilloscope _oscilloscope;

    public Channel(uint channelID, Oscilloscope oscilloscope)
    {
        _channelID = channelID;
        _oscilloscope = oscilloscope;
    }
    // --------- Channel commands
    public OnOff GetBwLimit()
    {
        _oscilloscope.Write(":CHAN" + _channelID + ":BWLimit?");
        return (OnOff)GetterSetterExtension.FromDescription<OnOff>(_oscilloscope.ReadString());
    }
    public void SetBwLimit(OnOff value)
    {
        _oscilloscope.Write(":CHAN" + _channelID + ":BWLimit " + value.SetterDescription());
    }
    // TODO: Coupling
    // TODO: Display
    // TODO: Invert
    public double GetOffset()
    {
        _oscilloscope.Write(":CHAN" + _channelID + ":OFFS?");
        return double.Parse(_oscilloscope.ReadString());
    }
    public void SetOffset(double value)
    {
        _oscilloscope.Write(":CHAN" + _channelID + ":OFFS " + value);
    }
    // TODO: Probe
    public double GetScale()
    {
        _oscilloscope.Write(":CHAN" + _channelID + ":SCAL?");
        return double.Parse(_oscilloscope.ReadString());
    }
    public void SetScale(double value)
    {
        _oscilloscope.Write(":CHAN" + _channelID + ":SCAL " + value);
    }
    public WaveForm GetWaveform()
    {
        _oscilloscope.Write(":WAVEFORM:DATA? CHAN" + _channelID);
        byte[] respose = _oscilloscope.Read();

        long pointsCount = respose.Length - 10;

        double[] data = new double[pointsCount];
        double[] times = new double[pointsCount];

        double scale = GetScale();
        double offset = GetOffset();
        double oscTimeScale = _oscilloscope.GetTimebaseScale();
        double oscTimeOffset = _oscilloscope.GetTimebaseOffset();
        double sampleRate = _oscilloscope.GetAcquireSamplingRate(_channelID);

        double initial, interval;

        // 600 points
        //T(s) = (<Pt_Num> - 1) * (<Time_Div> / 50) - [(<Time_Div> * 6) - <Time_Offset>]      
        // > 600 points
        //T(s) = <Time_Offset> -[ (<Points> - 10) / (1 / (2*<Samp_Rate>)]

        if (pointsCount > 600)
        {
            initial = -((1.0 / sampleRate) * (pointsCount / 2)) + oscTimeOffset;
            interval = 1.0 / sampleRate;
        }
        else
        {
            initial = -(oscTimeScale * 6) - oscTimeOffset;
            interval = oscTimeScale / 50;
        }

        for (int i = 0; i < pointsCount; i++)
        {
            // Strip off 10 byte header and loop through data and termination characters
            int rawData = (int)respose[i + 10];

            // Scale the vertical data from bytes to volts
            // A(V) = [(240 - <Raw_Byte>) * (<Volts_Div> / 25) - [(<Vert_Offset> + <Volts_Div> * 4.6)]]
            data[i] = ((240 - rawData) * scale / 25) - (offset + (scale * 4.6));
            times[i] = initial + interval * i;
        }

        return new WaveForm(times, data);
    }

    // TODO: Filter
    // TODO: Vernier  
    /// <remarks>From DS1000E/D Waveform Data Formatting Guide</remarks>
    /// <returns></returns>
    public WaveForm GetWaveformString()
    {
        _oscilloscope.Write(":WAVEFORM:DATA? CHAN" + _channelID);
        string respose = _oscilloscope.ReadString();

        long pointsCount = respose.Length - 10;

        //MessageBox.Show(pointsCount.ToString());
        double[] data = new double[pointsCount];
        double[] times = new double[pointsCount];

        double scale = GetScale();
        double offset = GetOffset();
        double oscTimeScale = _oscilloscope.GetTimebaseScale();
        double oscTimeOffset = _oscilloscope.GetTimebaseOffset();
        double sampleRate = _oscilloscope.GetAcquireSamplingRate(_channelID);

        double initial, interval;

        // 600 points
        //T(s) = (<Pt_Num> - 1) * (<Time_Div> / 50) - [(<Time_Div> * 6) - <Time_Offset>]      
        // > 600 points
        //T(s) = <Time_Offset> -[ (<Points> - 10) / (1 / (2*<Samp_Rate>)]

        if (pointsCount > 600)
        {
            initial = -((1.0 / sampleRate) * (pointsCount / 2)) + oscTimeOffset;
            interval = 1.0 / sampleRate;
        }
        else
        {
            initial = -(oscTimeScale * 6) - oscTimeOffset;
            interval = oscTimeScale / 50;
        }

        for (int i = 0; i < pointsCount; i++)
        {
            // Strip off 10 byte header and loop through data and termination characters
            int rawData = (int)respose[i + 10];

            // Scale the vertical data from bytes to volts
            // A(V) = [(240 - <Raw_Byte>) * (<Volts_Div> / 25) - [(<Vert_Offset> + <Volts_Div> * 4.6)]]
            data[i] = ((240 - rawData) * scale / 25) - (offset + (scale * 4.6));
            //data[i] = rawData;

            times[i] = initial + interval * i;
        }

        return new WaveForm(times, data);
    }
}