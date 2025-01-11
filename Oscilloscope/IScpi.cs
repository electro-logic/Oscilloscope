// Author: Leonardo Tazzini

using System;

/// <summary>
/// Basic TMC (Test and Measurement Class) interface
/// </summary>
public interface IScpi : IDisposable
{
    string[] GetResources();
    void Open(string resource);
    byte[] Read(long count);
    void Write(string str);
    string ReadString();
}