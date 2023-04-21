// Author: Leonardo Tazzini

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/// <summary>
/// Represent an Oscilloscope WaveForm composed by a list of Times and a list of one or more Values (if waveform contains multiple channels)
/// </summary>
public class WaveForm
{
    double[] _times;
    List<double[]> _values;

    public WaveForm(double[] times, List<double[]> values)
    {
        _times = times;
        _values = values;
    }

    public WaveForm(double[] times, double[] values)
    {
        _times = times;
        _values = new List<double[]>();
        _values.Add(values);
    }

    public double[] Times
    {
        get { return _times; }
        set { _times = value; }
    }

    public List<double[]> Values
    {
        get { return _values; }
        set { _values = value; }
    }

    /// <summary>
    /// Save Waveform in a CSV (Comma Separated Values) file separated by semicolon
    /// </summary>
    public void SaveCSV(string fileName)
    {
        StringBuilder sb = new StringBuilder(_times.Length * 10);

        int valuesCount = _values.Count;
        int timesCount = _times.Count();

        // Header
        sb.Append("TIME(s);");
        for (int j = 1; j < valuesCount + 1; j++)
        {
            sb.Append("CH");
            sb.Append(j);
            sb.Append("(v);");
        }
        sb.Append("\n");

        // Data
        for (int i = 0; i < timesCount; i++)
        {
            sb.Append(_times[i]);
            sb.Append(";");
            for (int j = 0; j < valuesCount; j++)
            {
                sb.Append(_values[j][i]);
                sb.Append(";");
            }
            sb.Append("\n");
        }

        //sb = sb.Replace('.', ',');                     // Excel ITA compatibility
        File.Delete(fileName);
        File.WriteAllText(fileName, sb.ToString());
    }

    //public string Build(int from, int to)
    //{
    //	StringBuilder sb = new StringBuilder((to - from) * 7);
    //	for (int i = from; i < to; i++)
    //	{
    //		sb.Append(_times[i]);
    //		sb.Append(";");
    //		for (int j = 0; j < _values.Count; j++)
    //		{
    //			sb.Append(_values[j][i] + ";");
    //		}
    //		sb.Append("\n");
    //	}
    //	return sb.ToString();
    //}

    //public void SaveBinary(string fileName)
    //{
    //  byte[] bytes = new byte[_times.Count()];
    //  for (int i = 0; i < _times.Count(); i++)
    //  {
    //    bytes[i] = (byte)_values[i];
    //  }
    //  File.WriteAllBytes(fileName, bytes);
    //}

    /*
	public void SaveOLS(string fileName, double samplingRate)
	{
		StringBuilder sb = new StringBuilder(_times.Length * 10);
		sb.AppendLine(";Rate: " + (int)samplingRate);
		sb.AppendLine(";Channels: 1");
		for (int i = 0; i < _times.Count(); i++)
		{
			sb.AppendLine(((Int32)_values[i]).ToString("X") + "@" + i.ToString("X"));
		}
		File.Delete(fileName);
		File.WriteAllText(fileName, sb.ToString());
	}
	*/

    /// <summary>
    /// Binarize Waveform Values given a threshold
    /// </summary>
    /// <returns></returns>
    public WaveForm Threshold(double threshold)
    {
        // Apply threshold to all channels
        for (int channelIndex = 0; channelIndex < _values.Count; channelIndex++)
        {
            for (int index = 0; index < _values[channelIndex].Length; index++)
            {
                if (_values[channelIndex][index] >= threshold)
                {
                    _values[channelIndex][index] = 1;
                }
                else
                {
                    _values[channelIndex][index] = 0;
                }
            }
        }
        return this;
    }
}