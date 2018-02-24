using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace OscilloscopeGUI
{
    static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      // With en-US culture handle all decimal separator with '.' also on non-en-US pc
      Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new FrmMain());
    }
  }
}
