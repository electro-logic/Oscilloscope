// Author: Leonardo Tazzini

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System.Threading;

namespace OscilloscopeTest
{
    [TestClass]
    public class UnitTestOscilloscope
    {
        Oscilloscope _osc = new Oscilloscope();

        [TestCleanup]
        [TestInitialize]
        [TestMethod]
        public void Initialize()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            _osc.SetAcquireAverages(AcquireAverages.Average16);
            _osc.SetAcquireMemoryDepth(AcquireMemoryDepth.Normal);
            _osc.SetAcquireMode(AcquireMode.EquiTime);
            _osc.SetAcquireType(AcquireType.Normal);
            _osc.SetTimebaseFormat(TimebaseFormat.YT);
            _osc.SetTimebaseMode(TimebaseMode.Main);
            _osc.SetTriggerSweep(TriggerSweep.Normal);
            _osc.SetWaveformPointsMode(PointsMode.Normal);
            _osc.SetTimebaseScale(0.001);
            _osc.SetTimebaseOffset(0);
        }

        /// <summary>
        /// TODO: Document
        /// </summary>
        public void TestGetterSetter<T>(Func<T> getter, Action<T> setter)
        {
            Array enums = Enum.GetValues(typeof(T));
            foreach (T enumObj in enums)
            {
                setter(enumObj);
                Assert.AreEqual(enumObj, getter());
            }

            // Test first Setter in case of already set enum
            T firstEnumObj = (T)enums.GetValue(0);
            setter(firstEnumObj);
            Assert.AreEqual(firstEnumObj, getter());
        }

        [TestMethod]
        public void TestAcquire()
        {
            TestGetterSetter<AcquireType>(_osc.GetAcquireType, _osc.SetAcquireType);
            TestGetterSetter<AcquireMode>(_osc.GetAcquireMode, _osc.SetAcquireMode);
            TestGetterSetter<AcquireAverages>(_osc.GetAcquireAverages, _osc.SetAcquireAverages);
            TestGetterSetter<AcquireMemoryDepth>(_osc.GetAcquireMemoryDepth, _osc.SetAcquireMemoryDepth);
        }

        //[TestMethod]
        //public void TestAcquireSamplingRate()
        //{
        //	// TODO: Set sampling rate changing timebase scale
        //	double samplingRate = _osc.GetAcquireSamplingRate(1);
        //	Assert.AreEqual(1.0, samplingRate);
        //}

        [TestMethod]
        public void TestTimebase()
        {
            //TestGetterSetter<TimebaseMode>(_osc.GetTimebaseMode, _osc.SetTimebaseMode);
            // TODO
            // _osc.GetTimebaseOffset
            // _osc.GetTimebaseScale
            TestGetterSetter<TimebaseFormat>(_osc.GetTimebaseFormat, _osc.SetTimebaseFormat);
        }

        [TestMethod]
        public void TestTrigger()
        {
            TestGetterSetter<TriggerSweep>(_osc.GetTriggerSweep, _osc.SetTriggerSweep);
            // TODO others
        }
    }
}
