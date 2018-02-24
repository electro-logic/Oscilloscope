// Author: Leonardo Tazzini

// Enumerations used by Oscilloscope annotated with GetterSetterAttribute

public enum OnOff
{
  [GetterSetterAttribute("ON")]
  On,
  [GetterSetterAttribute("OFF")]
  Off
}

// --------- Acquire enums

public enum AcquireType
{
  [GetterSetterAttribute("NORMAL")]
  Normal,
  [GetterSetterAttribute("AVERAGE")]
  Average,
  [GetterSetterAttribute("Peak Detect", "PEAKDETECT")]
  PeakDetect
}

public enum AcquireMode
{
  [GetterSetterAttribute("REAL_TIME", "RTIM")]
  RealTime,
  [GetterSetterAttribute("EQUAL_TIME", "ETIM")]
  EquiTime
}

public enum AcquireAverages
{
  [GetterSetterAttribute("2")]
  Average2,
  [GetterSetterAttribute("4")]
  Average4,
  [GetterSetterAttribute("8")]
  Average8,
  [GetterSetterAttribute("16")]
  Average16,
  [GetterSetterAttribute("32")]
  Average32,
  [GetterSetterAttribute("64")]
  Average64,
  [GetterSetterAttribute("128")]
  Average128,
  [GetterSetterAttribute("256")]
  Average256
}

public enum AcquireMemoryDepth
{
  [GetterSetterAttribute("NORMAL")]
  Normal,
  [GetterSetterAttribute("LONG")]
  Long
}

// --------- Display enums

public enum DisplayType
{
  [GetterSetterAttribute("VECTORS")]
  Vectors,
  [GetterSetterAttribute("DOTS")]
  Dots
}

public enum DisplayGrid
{
  [GetterSetterAttribute("FULL")]
  Full,
  [GetterSetterAttribute("HALF")]
  Half,
  [GetterSetterAttribute("NONE")]
  None
}

public enum DisplayMenu
{
  [GetterSetterAttribute("1s", "1")]
  One,
  [GetterSetterAttribute("2s", "2")]
  Two,
  [GetterSetterAttribute("5s", "5")]
  Five,
  [GetterSetterAttribute("10s", "10")]
  Ten,
  [GetterSetterAttribute("20s", "20")]
  Twelve,
  [GetterSetterAttribute("Infinite", "Infinite")]
  Infinite
}

// --------- Timebase enums

public enum TimebaseMode
{
  [GetterSetterAttribute("MAIN")]
  Main,
  [GetterSetterAttribute("DELAYED")]
  Delayed
}

public enum TimebaseFormat
{
  [GetterSetterAttribute("X-Y", "XY")]
  XY,
  [GetterSetterAttribute("Y-T", "YT")]
  YT,
  [GetterSetterAttribute("SCANNING")]
  Scanning
}

// --------- Trigger enums

public enum TriggerMode
{
  [GetterSetterAttribute("EDGE")]
  Edge,
  [GetterSetterAttribute("PULS")]
  Pulse,
  [GetterSetterAttribute("VIDEO")]
  Video,
  [GetterSetterAttribute("SLOP")]
  Slope,
  [GetterSetterAttribute("PATT")]
  Pattern,
  [GetterSetterAttribute("DUR")]
  Duration,
  [GetterSetterAttribute("ALT")]
  Alternation
}

public enum TriggerSource
{
  [GetterSetterAttribute("CHAN1")]
  Channel1,
  [GetterSetterAttribute("CHAN2")]
  Channel2,
  [GetterSetterAttribute("EXT")]
  External,
  [GetterSetterAttribute("ACL")]
  ACLine,
  [GetterSetterAttribute("DIG")]
  Digital
}

public enum TriggerSweep
{
  [GetterSetterAttribute("AUTO")]
  Auto,
  [GetterSetterAttribute("NORMAL")]
  Normal,
  [GetterSetterAttribute("SINGLE")]
  Single
}

public enum TriggerCoupling
{
  /// <summary>
  /// Allow all signals pass.
  /// </summary>
  [GetterSetterAttribute("DC")]
  DC,
  /// <summary>
  /// Block DC signals and attenuate the signals lower than 10Hz.
  /// </summary>
  [GetterSetterAttribute("AC")]
  AC,
  /// <summary>
  /// Reject high frequency signals (Higher than 150KHz).
  /// </summary>
  [GetterSetterAttribute("HF")]
  HF,
  /// <summary>
  /// Reject DC signals and attenuate low frequency signals (Lower than 8KHz).
  /// </summary>
  [GetterSetterAttribute("LF")]
  LF
}

public enum TriggerStatus
{
  [GetterSetterAttribute("RUN")]
  Run,
  [GetterSetterAttribute("STOP")]
  Stop,
  [GetterSetterAttribute("T'D")]
  TD,
  [GetterSetterAttribute("WAIT")]
  Wait,
  [GetterSetterAttribute("AUTO")]
  Auto
}

// --------- Math enums

public enum MathOperate
{
  [GetterSetterAttribute("A+B")]
  AplusB,
  [GetterSetterAttribute("A-B")]
  AminusB,
  [GetterSetterAttribute("AB")]
  AB,
  [GetterSetterAttribute("FFT")]
  FFT
}

// --------- Wavewform enums

public enum PointsMode
{
  [GetterSetterAttribute("NORMAL")]
  Normal,
  [GetterSetterAttribute("MAXIMUM")]
  Maximum,
  [GetterSetterAttribute("RAW")]
  Raw
}