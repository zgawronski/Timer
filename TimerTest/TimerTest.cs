using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimerLib;
 
namespace TimerTest
{
    [TestClass]
    public class TimerTest
    {
        #region Constructor Time==========================

        [TestMethod, TestCategory("Constructor Time")]
        public void Constructor_Time_Default()
        {
            var time = new Time();
            var defaultTime = new Time(0, 00, 00);
            Assert.AreEqual(defaultTime, time);
        }

        [TestMethod, TestCategory("Constructor Time")]
        public void Constructor_Time_ToString()
        {
            var t1 = new Time();
            var t2 = new Time(12, 58, 17);

            Assert.AreEqual("00:00:00", t1.ToString());
            Assert.AreEqual("12:58:17", t2.ToString());
        }

        [TestMethod, TestCategory("Constructor Time")]

        public void Constructor_Time_Hour()
        {
            Time t1 = new Time(4);
            Time t2 = new Time(20);

            Assert.AreEqual("04:00:00", t1.ToString());
            Assert.AreEqual("20:00:00", t2.ToString());
        }
        [TestMethod, TestCategory("Constructor Time")]

        public void Constructor_Time_Hour_Minutes()
        {
            Time t1 = new Time(4, 36);
            Time t2 = new Time(5, 46, 57);

            Assert.AreEqual("04:36:00", t1.ToString());
            Assert.AreEqual("05:46:57", t2.ToString());
        }

        [TestMethod, TestCategory("Constructor Time")]
        public void Constructor_Time_Hour_Minutes_Seconsd()
        {
            Time t1 = new Time(12, 39, 25);
            Time t2 = new Time(22, 22, 22);

            Assert.AreEqual("12:39:25", t1.ToString());
            Assert.AreEqual("22:22:22", t2.ToString());
        }

        [TestMethod, TestCategory("Constructor Time")]
        public void Constructor_Time_String_Hour()
        {
            Time t1 = new Time("1");
            Time t2 = new Time("23");

            Assert.AreEqual("01:00:00", t1.ToString());
            Assert.AreEqual("23:00:00", t2.ToString());
        }
        [TestMethod, TestCategory("Constructor Time")]
        public void Constructor_Time_String_Hour_Minutes()
        {
            Time t1 = new Time("14:38");
            Time t2 = new Time("21:21");

            Assert.AreEqual("14:38:00", t1.ToString());
            Assert.AreEqual("21:21:00", t2.ToString());
        }
        [TestMethod, TestCategory("Constructor Time")]
        public void Constructor_Time_String_Hour_Minutes_Seconds()
        {
            Time t1 = new Time("12:12:12");
            Time t2 = new Time("23:23:23");

            Assert.AreEqual("12:12:12", t1.ToString());
            Assert.AreEqual("23:23:23", t2.ToString());
        }

        #endregion

        #region Time Operators==================


        [TestMethod, TestCategory("Equals Time")]
        public void Time_Equals()
        {
            Time t1 = new Time(7, 17);
            Time t2 = new Time(7, 17);
            Time t3 = new Time(7, 17, 17);

            Assert.IsTrue(t1.Equals(t2));
            Assert.IsFalse(t1.Equals(t3));
        }
        [TestMethod, TestCategory("Equals Time")]
        public void Time_Operator_Equals()
        {
            Time t1 = new Time(7, 17);
            Time t2 = new Time(7, 17);
            Time t3 = new Time(17, 17, 17);

            Assert.IsTrue(t1 == t2);
            Assert.IsTrue(t1 != t3);
        }
        [TestMethod, TestCategory("Equals Time")]
        public void Time_Operator_Smaller()
        {
            Time t1 = new Time(7, 17);
            Time t2 = new Time(7, 17, 17);
            Time t3 = new Time(17, 17, 17);

            Assert.IsTrue(t1 < t2);
            Assert.IsTrue(t1 < t3);
            Assert.IsFalse(t3 < t1);
        }
        [TestMethod, TestCategory("Equals Time")]
        public void Time_Operator_Bigger()
        {
            Time t1 = new Time(7, 17);
            Time t2 = new Time(7, 17, 17);
            Time t3 = new Time(17, 17, 17);

            Assert.IsTrue(t2 > t1);
            Assert.IsTrue(t3 > t1);
            Assert.IsFalse(t1 > t3);
        }
        [TestMethod, TestCategory("Equals Time")]
        public void Time_Operator_Smaller_Equals()
        {
            Time t1 = new Time(7, 17);
            Time t2 = new Time(7, 17);
            Time t3 = new Time(22, 22, 22);

            Assert.IsTrue(t1 <= t2);
            Assert.IsTrue(t1 <= t3);
            Assert.IsFalse(t3 <= t2);
        }
        [TestMethod, TestCategory("Equals Time")]
        public void Time_Operator_Bigger_Equals()
        {
            Time t1 = new Time(7, 17);
            Time t2 = new Time(7, 17);
            Time t3 = new Time(22, 22, 22);

            Assert.IsTrue(t2 >= t1);
            Assert.IsTrue(t3 >= t1);
            Assert.IsFalse(t2 >= t3);
        }

        [TestMethod, TestCategory("Operator Time")]
        public void Time_Operator_Plus()
        {
            Time t1 = new Time(2, 17, 17);
            TimePeriod tp1 = new TimePeriod("1:03:03");
            Time t2 = new Time(12, 30, 58);
            TimePeriod tp2 = new TimePeriod("10:10:12");

            Time tt1 = t1 + tp1;
            Time tt2 = t2 + tp2;

            Assert.AreEqual("03:20:20", tt1.ToString());
            Assert.AreEqual("22:41:10", tt2.ToString());

        }
        [TestMethod, TestCategory("Operator Time")]
        public void Time_Method_Plus()
        {
            Time t1 = new Time(2, 17, 17);
            TimePeriod tp1 = new TimePeriod("1:03:03");
            Time t2 = new Time(12, 30, 58);
            TimePeriod tp2 = new TimePeriod("10:10:12");

            Time tt1 = t1 + tp1;
            Time tt2 = t2 + tp2;

            t1.PlusTime(tp1);
            t2.PlusTime(tp2);


            Assert.AreEqual(tt1, t1);
            Assert.AreEqual(tt2, t2);

        }
        [TestMethod, TestCategory("Operator Time")]
        public void Time_Operator_Minus()
        {
            Time t1 = new Time(2, 17, 17);
            TimePeriod tp1 = new TimePeriod("1:03:03");
            Time t2 = new Time(12, 30, 58);
            TimePeriod tp2 = new TimePeriod("10:10:12");

            Time tt1 = t1 - tp1;
            Time tt2 = t2 - tp2;

            Assert.AreEqual("01:14:14", tt1.ToString());
            Assert.AreEqual("02:20:46", tt2.ToString());

        }

        #endregion

        #region Constructor TimePeriod================

        [TestMethod, TestCategory("Constructor TimePeriod")]
        public void Constructor_TimePeriod_Hour_Minutes_Seconds()
        {
            TimePeriod tp1 = new TimePeriod(12, 34, 56);
            TimePeriod tp2 = new TimePeriod(153, 12, 34);

            Assert.AreEqual("12:34:56", tp1.ToString());
            Assert.AreEqual("153:12:34", tp2.ToString());
        }

        [TestMethod, TestCategory("Constructor TimePeriod")]
        public void Constructor_TimePeriod_Hour_Minutes()
        {
            TimePeriod tp1 = new TimePeriod(12, 34);
            TimePeriod tp2 = new TimePeriod(153, 12);

            Assert.AreEqual("12:34:00", tp1.ToString());
            Assert.AreEqual("153:12:00", tp2.ToString());
        }
        [TestMethod, TestCategory("Constructor TimePeriod")]
        public void Constructor_TimePeriod_Seconds()
        {
            TimePeriod tp1 = new TimePeriod(1236);
            TimePeriod tp2 = new TimePeriod(45678);
            TimePeriod tp3 = new TimePeriod(1234567);

            Assert.AreEqual("0:20:36", tp1.ToString());
            Assert.AreEqual("12:41:18", tp2.ToString());
            Assert.AreEqual("342:56:07", tp3.ToString());
        }
        [TestMethod, TestCategory("Constructor TimePeriod")]
        public void Constructor_TimePeriod_String()
        {
            TimePeriod tp1 = new TimePeriod("1:23:45");
            TimePeriod tp2 = new TimePeriod("0:00:01");
            TimePeriod tp3 = new TimePeriod("34:56:07");

            Assert.AreEqual("1:23:45", tp1.ToString());
            Assert.AreEqual("0:00:01", tp2.ToString());
            Assert.AreEqual(125767, tp3.Seconds);
        }

        #endregion

        #region TimePeriod Operators============

        [TestMethod, TestCategory("Equals TimePeriod")]
        public void TimePeriod_Equlas()
        {
            TimePeriod tp1 = new TimePeriod(28, 28, 28);
            TimePeriod tp2 = new TimePeriod("28:28:28");
            TimePeriod tp3 = new TimePeriod(282828);

            Assert.IsTrue(tp1.Equals(tp2));
            Assert.IsFalse(tp1.Equals(tp3));
        }

        [TestMethod, TestCategory("Equals TimePeriod")]
        public void TimePeriod_Operator_Equals()
        {
            TimePeriod tp1 = new TimePeriod(28, 28, 28);
            TimePeriod tp2 = new TimePeriod("28:28:28");
            TimePeriod tp3 = new TimePeriod(282828);

            Assert.IsTrue(tp1 == tp2);
            Assert.IsTrue(tp1 != tp3);
        }
        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Operator_Samller()
        {
            TimePeriod tp1 = new TimePeriod(28, 28, 28);
            TimePeriod tp2 = new TimePeriod("41:41:41");
            TimePeriod tp3 = new TimePeriod(728);

            Assert.IsTrue(tp1 < tp2);
            Assert.IsFalse(tp1 < tp3);
        }
        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Operator_Bigger()
        {
            TimePeriod tp1 = new TimePeriod(28, 28, 28);
            TimePeriod tp2 = new TimePeriod("26:26:26");
            TimePeriod tp3 = new TimePeriod(28282828);

            Assert.IsTrue(tp1 > tp2);
            Assert.IsFalse(tp1 > tp3);
        }
        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Operator_Smaller_Equals()
        {
            TimePeriod tp1 = new TimePeriod(28, 28, 28);
            TimePeriod tp2 = new TimePeriod("28:28:28");
            TimePeriod tp3 = new TimePeriod(28282828);

            Assert.IsTrue(tp1 <= tp2);
            Assert.IsTrue(tp1 <= tp3);
            Assert.IsFalse(tp3 <= tp1);
        }
        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Operator_Bigger_Equals()
        {
            TimePeriod tp1 = new TimePeriod(28, 28, 28);
            TimePeriod tp2 = new TimePeriod("28:28:28");
            TimePeriod tp3 = new TimePeriod(28282828);

            Assert.IsTrue(tp2 >= tp1);
            Assert.IsTrue(tp3 >= tp1);
            Assert.IsFalse(tp1 >= tp3);
        }

        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Operator_Plus()
        {
            TimePeriod tp1 = new TimePeriod(28, 28, 28);
            TimePeriod tp2 = new TimePeriod("28:28:28");
            TimePeriod tp3 = new TimePeriod(102508);

            TimePeriod ttp = tp1 + tp2;
            TimePeriod ttp0 = tp1 + tp3;

            Assert.AreEqual("56:56:56", ttp.ToString());
            Assert.AreEqual("56:56:56", ttp0.ToString());

        }
        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Method_Plus()
        {
            TimePeriod tp1 = new TimePeriod(28, 28, 28);
            TimePeriod tp2 = new TimePeriod("28:28:28");
            TimePeriod tp3 = new TimePeriod(102508);

            TimePeriod ttp = tp1 + tp2;
            TimePeriod ttp0 = tp1 + tp3;

            Assert.AreEqual(ttp, tp1 + tp2);
            Assert.AreEqual(ttp0, tp1 + tp3);

        }
        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Operator_Minus()
        {
            TimePeriod tp1 = new TimePeriod(28, 28, 28);
            TimePeriod tp2 = new TimePeriod("28:28:28");
            TimePeriod tp3 = new TimePeriod(98847);

            TimePeriod ttp = tp1 - tp2;
            TimePeriod ttp0 = tp1 - tp3;

            Assert.AreEqual("0:00:00", ttp.ToString());
            Assert.AreEqual("1:01:01", ttp0.ToString());

        }

        #endregion
    }
}
