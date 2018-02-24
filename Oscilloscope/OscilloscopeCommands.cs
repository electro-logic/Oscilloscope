// Author: Leonardo Tazzini

using System;

public partial class Oscilloscope
{
    // --------- System Commands

    /// <summary>
    /// The command initiates the oscilloscope to acquire waveform data according to its current settings.
    /// Acquisition runs continuously until the oscilloscope receives a STOP command.
    /// </summary>
    public void Run()
    {
        Write(":RUN");
    }

    /// <summary>
    /// The command resets the system parameters.
    /// </summary>
    public void Reset()
    {
        Write("*RST");
    }

    /// <summary>
    /// The command controls the oscilloscope to stop acquiring data. To restart the acquisition, use the RUN command.
    /// </summary>
    public void Stop()
    {
        Write(":STOP");
    }

    /// <summary>
    /// The command controls the oscilloscope to evaluate all input waveforms characteristics and set the optimum conditions to display the waveforms.
    /// </summary>
    public void Auto()
    {
        Write(":AUTO");
    }

    /// <summary>
    /// The command is to extract the current information on the screen and save the bitmap into the U disc in the form of “HardCopyxxx.bmp”.        
    /// </summary>
    /// <remarks>
    /// This command is unavailable in file system
    /// </remarks>
    public void HardCopy()
    {
        Write(":HARDcopy");
    }

    // --------- Acquire commands

    /// <summary>
    /// Query current acquire type of the oscilloscope.
    /// </summary>    
    public AcquireType GetAcquireType()
    {
        Write(":ACQ:TYPE?");
        return (AcquireType)GetterSetterExtension.FromDescription<AcquireType>(ReadString());
    }

    /// <summary>
    /// Set current acquire type of the oscilloscope.
    /// </summary>
    public void SetAcquireType(AcquireType memoryDepth)
    {

        Write(":ACQ:TYPE " + memoryDepth.SetterDescription());
    }

    /// <summary>
    /// Query current acquire mode of the oscilloscope.
    /// </summary>    
    public AcquireMode GetAcquireMode()
    {
        Write(":ACQuire:MODE?");
        return (AcquireMode)GetterSetterExtension.FromDescription<AcquireMode>(ReadString());
    }

    /// <summary>
    /// Set current acquire mode of the oscilloscope.
    /// </summary>
    public void SetAcquireMode(AcquireMode memoryDepth)
    {
        Write(":ACQuire:MODE " + memoryDepth.SetterDescription());
    }

    /// <summary>
    /// Query average numbers in Average mode.
    /// </summary>    
    public AcquireAverages GetAcquireAverages()
    {
        Write(":ACQuire:AVERages?");
        return (AcquireAverages)GetterSetterExtension.FromDescription<AcquireAverages>(ReadString());
    }

    /// <summary>
    /// Set average numbers in Average mode.
    /// </summary>
    public void SetAcquireAverages(AcquireAverages acquireAverage)
    {
        Write(":ACQuire:AVERages " + acquireAverage.SetterDescription());
    }

    /// <summary>
    /// Queries the current sampling rate of the analog channel or digital channel (only for DS1000D series). <n> is 1 or 2 means channel 1 or channel 2.
    /// </summary>    
    public double GetAcquireSamplingRate(uint channel)
    {
        if (channel > _numChannels)
        {
            throw new ArgumentException("Wrong channel");
        }
        // TODO: Digital channel of DS1000D not supported			
        Write(":ACQuire:SAMPlingrate? CHANnel" + channel);
        return double.Parse(ReadString());
    }

    /// <summary>
    /// Query the memory depth of the oscilloscope.
    /// </summary>		
    public AcquireMemoryDepth GetAcquireMemoryDepth()
    {
        Write(":ACQuire:MEMDepth?");
        return (AcquireMemoryDepth)GetterSetterExtension.FromDescription<AcquireMemoryDepth>(ReadString());
    }

    /// <summary>
    /// Set the memory depth of the oscilloscope.
    /// </summary>
    public void SetAcquireMemoryDepth(AcquireMemoryDepth memoryDepth)
    {
        Write(":ACQuire:MEMDepth " + memoryDepth.SetterDescription());
    }

    // --------- Display commands
    // TODO

    // --------- Timebase commands

    /// <summary>
    /// Query scan mode of horizontal timebase
    /// </summary>		
    public TimebaseMode GetTimebaseMode()
    {
        Write(":TIMebase:MODE?");
        return (TimebaseMode)GetterSetterExtension.FromDescription<TimebaseMode>(ReadString());
    }

    /// <summary>
    /// Set scan mode of horizontal timebase
    /// </summary>	
    public void SetTimebaseMode(TimebaseMode value)
    {
        Write(":TIMebase:MODE " + value.SetterDescription());
    }

    /// <summary>
    /// Query the offset of the MAIN or DELayed timebase 
    /// (that is offset of the waveform position relative to the trigger midpoint.). 		
    /// In NORMAL mode, the range of <scale_val> is 1s ~ end of the memory;
    /// In STOP mode, the range of <scale_val> is -500s ~ +500s;
    /// In SCAN mode, the range of <scale_val> is -6*Scale ~ +6*Scale; (Note: Scale indicates the current horizontal scale, the unit is s/div.)
    /// In MAIN state, the item [:DELayed] should be omitted.
    /// </summary>		
    public double GetTimebaseOffset()
    {
        // TODO: Delayed option
        Write(":TIMebase:OFFS?");
        return double.Parse(ReadString());
    }

    /// <summary>
    /// Set the offset of the MAIN or DELayed timebase 
    /// </summary>
    public void SetTimebaseOffset(double value)
    {
        // TODO: Delayed option
        Write(":TIMebase:OFFSet " + value);
    }

    /// <summary>
    /// Query the horizontal scale for MAIN or DELayed timebase, the unit is s/div (seconds/grid), thereinto:
    /// In YT mode, the range of <scale_val> is 2ns - 50s;
    /// In ROLL mode, the range of <scale_val> is 500ms - 50s;
    /// In MAIN state, the item [:DELayed] should be omitted.
    /// </summary>
    public double GetTimebaseScale()
    {
        // TODO: Delayed option
        Write(":TIMebase:SCALe?");
        return double.Parse(ReadString());
    }

    /// <summary>
    /// Set the horizontal scale for MAIN or DELayed timebase, the unit is s/div (seconds/grid)
    /// </summary>
    public void SetTimebaseScale(double value)
    {
        // TODO: Delayed option
        Write(":TIMebase:SCALe " + value);
    }


    /// <summary>
    /// Query the horizontal timebase
    /// </summary>
    public TimebaseFormat GetTimebaseFormat()
    {
        // TODO: Delayed option
        Write(":TIMebase:FORMat?");
        return (TimebaseFormat)GetterSetterExtension.FromDescription<TimebaseFormat>(ReadString());
    }

    /// <summary>
    /// Set the horizontal timebase
    /// </summary>
    public void SetTimebaseFormat(TimebaseFormat value)
    {
        // TODO: Delayed option
        Write(":TIMebase:FORMat " + value.SetterDescription());
    }

    // --------- Trigger commands

    // TODO: Complete

    /// <summary>
    /// Queries the operating status of the oscilloscope. The status could be RUN, STOP, T`D, WAIT or AUTO
    /// </summary>		
    public TriggerStatus GetTriggerStatus()
    {
        Write(":TRIGger:STATus?");
        return (TriggerStatus)GetterSetterExtension.FromDescription<TriggerStatus>(ReadString());
    }

    public TriggerSweep GetTriggerSweep()
    {
        Write(":TRIGger:EDGE:SWEep?");
        return (TriggerSweep)GetterSetterExtension.FromDescription<TriggerSweep>(ReadString());
    }

    public void SetTriggerSweep(TriggerSweep memoryDepth)
    {
        Write(":TRIGger:EDGE:SWEep " + memoryDepth.SetterDescription());
    }

    /// <summary>
    /// Sets the trigger level to the vertical midpoint of amplitude.
    /// </summary>
    public void TriggerHalf()
    {
        Write(":Trig%50");
    }

    /// <summary>
    /// Forces the oscilloscope to trigger signal, which is usually used in “Normal” and “Single” mode.
    /// </summary>
    public void TriggerForce()
    {
        Write(":FORCetrig");
    }

    // --------- Storage commands (uncomment to enable it)

    /// <summary>
    /// Recalls the system settings before leaving factory.
    /// </summary>
    //public void StorageFactoryLoad()
    //{
    //  Write(":STORage:FACTory:LOAD");
    //}

    // --------- Math commands

    /// <summary>
    /// Query the On/Off state of the math operation
    /// </summary>    
    public OnOff GetMathDisplay()
    {
        Write(":MATH:DISPlay?");
        return (OnOff)GetterSetterExtension.FromDescription<OnOff>(ReadString());
    }

    /// <summary>
    /// Set the On/Off state of the math operation
    /// </summary>
    public void SetMathDisplay(OnOff display)
    {
        Write(":MATH:DISPlay " + display.SetterDescription());
    }

    // --------- Measure commands

    // --------- Waveform commands

    // :WAVeform:DATA? is in GetWaveform() in Channel class

    /// <summary>
    /// Query mode of waveform points
    /// </summary>		
    public PointsMode GetWaveformPointsMode()
    {
        Write(":WAVeform:POINts:MODE?");
        return (PointsMode)GetterSetterExtension.FromDescription<PointsMode>(ReadString());
    }

    /// <summary>
    /// Set mode of waveform points
    /// </summary>
    public void SetWaveformPointsMode(PointsMode value)
    {
        Write(":WAVeform:POINts:MODE " + value.SetterDescription());
    }

    // --------- LA commands
    // --------- Key commands

    /// <summary>
    /// The command unlocks the remote control.
    /// </summary>
    public void Close()
    {
        Write(":KEY:FORCE");
    }

}