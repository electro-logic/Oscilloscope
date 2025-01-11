// Author: Leonardo Tazzini
using NationalInstruments.Visa;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

// Note: VISA dependant class
public class VisaScpi : IScpiTmc
{
    MessageBasedSession _mbSession;
    static ResourceManager _resManager = new ResourceManager();
    bool _isDisposed;

    public void Open(string resource)
    {
        // Create Message based session, open first resource found
        _mbSession = (MessageBasedSession)_resManager.Open(_resManager.Find(resource).First());
        _mbSession.TimeoutMilliseconds = 1000 * 60 * 5;
    }
    public string[] GetResources()
    {
        string[] results = new string[] { };
        try
        {
            results = _resManager.Find("?*").ToArray();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        return results;
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
        // Read the response; omit end-of-line characters.
        return _mbSession.RawIO.ReadString().TrimEnd('\r', '\n');
    }
    public byte[] Read(long count)
    {
        var readBytes = _mbSession.RawIO.Read(count, out var status);
        Debug.WriteLine(string.Format("Readed {0} bytes from device with Status {1}", readBytes.Length, status));
        return readBytes;
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!_isDisposed)
        {
            if (disposing)
            {
                _mbSession.Dispose();
            }
            _isDisposed = true;
        }
    }
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
