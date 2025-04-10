// Author: Leonardo Tazzini

using System;
using System.IO.Ports;
using System.Linq;
using System.Threading;

public class SerialScpi : IScpi
{
    SerialPort _serial;
    public void Dispose() { }
    public string[] GetResources()
    {
        return SerialPort.GetPortNames().Select(x => x + " [38400 bps]").ToArray();
    }
    public void Open(string resource)
    {
        _serial = new SerialPort(resource, 38400, Parity.None, 8, StopBits.One);
        _serial.NewLine = "\n";
        _serial.ReadBufferSize = 1024 * 1024 * 8; // 8 MBytes
        _serial.Open();
    }
    public byte[] Read(long count)
    {
        if (_serial.ReadBufferSize < count)
        {
            throw new Exception("Increase the SerialPort read buffer");
        }
        while (_serial.BytesToRead != count)
        {
            Thread.Sleep(100);
        }
        var buffer = new byte[count];
        _serial.BaseStream.ReadExactly(buffer, 0, (int)count);
        return buffer;
    }
    public string ReadString()
    {
        var str = _serial.ReadLine();
        return str;
    }
    public void Write(string str)
    {
        _serial.WriteLine(str);
        _serial.BaseStream.Flush();
    }
}