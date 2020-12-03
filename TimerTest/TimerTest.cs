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
            var t2 = new Time(14, 53, 11);

            Assert.AreEqual("0:00:00", t1.ToString());
            Assert.AreEqual("14:53:11", t2.ToString());
        }

        [TestMethod, TestCategory("Constructor Time")]

        public void Constructor_Time_Hour()
        {
            Time t1 = new Time(8);
            Time t2 = new Time(11);

            Assert.AreEqual("8:00:00", t1.ToString());
            Assert.AreEqual("11:00:00", t2.ToString());
        }
        [TestMethod, TestCategory("Constructor Time")]

        public void Constructor_Time_Hour_Minutes()
        {
            Time t1 = new Time(8, 46);
            Time t2 = new Time(8, 46, 52);

            Assert.AreEqual("8:46:00", t1.ToString());
            Assert.AreEqual("8:46:52", t2.ToString());
        }

        [TestMethod, TestCategory("Constructor Time")]
        public void Constructor_Time_Hour_Minutes_Seconsd()
        {
            Time t1 = new Time(8, 46, 35);
            Time t2 = new Time(23, 46, 15);

            Assert.AreEqual("8:46:35", t1.ToString());
            Assert.AreEqual("23:46:15", t2.ToString());
        }

        [TestMethod, TestCategory("Constructor Time")]
        public void Constructor_Time_String_Hour()
        {
            Time t1 = new Time("12");
            Time t2 = new Time("23");

            Assert.AreEqual("12:00:00", t1.ToString());
            Assert.AreEqual("23:00:00", t2.ToString());
        }
        [TestMethod, TestCategory("Constructor Time")]
        public void Constructor_Time_String_Hour_Minutes()
        {
            Time t1 = new Time("12:53");
            Time t2 = new Time("23:21");

            Assert.AreEqual("12:53:00", t1.ToString());
            Assert.AreEqual("23:21:00", t2.ToString());
        }
        [TestMethod, TestCategory("Constructor Time")]
        public void Constructor_Time_String_Hour_Minutes_Seconds()
        {
            Time t1 = new Time("12:21:02");
            Time t2 = new Time("23:53:33");

            Assert.AreEqual("12:21:02", t1.ToString());
            Assert.AreEqual("23:53:33", t2.ToString());
        }

        #endregion

        #region Time Operators==================


        [TestMethod, TestCategory("Equals Time")]
        public void Time_Equals()
        {
            Time t1 = new Time(8, 15);
            Time t2 = new Time(8, 15);
            Time t3 = new Time(8, 25, 53);

            Assert.IsTrue(t1.Equals(t2));
            Assert.IsFalse(t1.Equals(t3));
        }
        [TestMethod, TestCategory("Equals Time")]
        public void Time_Operator_Equals()
        {
            Time t1 = new Time(8, 15);
            Time t2 = new Time(8, 15);
            Time t3 = new Time(15, 25, 53);

            Assert.IsTrue(t1 == t2);
            Assert.IsTrue(t1 != t3);
        }
        [TestMethod, TestCategory("Equals Time")]
        public void Time_Operator_Smaller()
        {
            Time t1 = new Time(8, 15);
            Time t2 = new Time(8, 15, 44);
            Time t3 = new Time(12, 25, 53);

            Assert.IsTrue(t1 < t2);
            Assert.IsTrue(t1 < t3);
            Assert.IsFalse(t3 < t1);
        }
        [TestMethod, TestCategory("Equals Time")]
        public void Time_Operator_Bigger()
        {
            Time t1 = new Time(8, 15);
            Time t2 = new Time(8, 15, 44);
            Time t3 = new Time(11, 25, 53);

            Assert.IsTrue(t2 > t1);
            Assert.IsTrue(t3 > t1);
            Assert.IsFalse(t1 > t3);
        }
        [TestMethod, TestCategory("Equals Time")]
        public void Time_Operator_Smaller_Equals()
        {
            Time t1 = new Time(8, 15);
            Time t2 = new Time(8, 15);
            Time t3 = new Time(9, 25, 53);

            Assert.IsTrue(t1 <= t2);
            Assert.IsTrue(t1 <= t3);
            Assert.IsFalse(t3 <= t2);
        }
        [TestMethod, TestCategory("Equals Time")]
        public void Time_Operator_Bigger_Equals()
        {
            Time t1 = new Time(8, 15);
            Time t2 = new Time(8, 15);
            Time t3 = new Time(9, 25, 53);

            Assert.IsTrue(t2 >= t1);
            Assert.IsTrue(t3 >= t1);
            Assert.IsFalse(t2 >= t3);
        }

        [TestMethod, TestCategory("Operator Time")]
        public void Time_Operator_Plus()
        {
            Time t1 = new Time(3, 15, 32);
            TimePeriod tp1 = new TimePeriod("2:18:42");
            Time t2 = new Time(17, 31, 59);
            TimePeriod tp2 = new TimePeriod("26:10:46");

            Time tt1 = t1 + tp1;
            Time tt2 = t2 + tp2;

            Assert.AreEqual("5:34:14", tt1.ToString());
            Assert.AreEqual("19:42:45", tt2.ToString());

        }
        [TestMethod, TestCategory("Operator Time")]
        public void Time_Method_Plus()
        {
            Time t1 = new Time(3, 15, 32);
            TimePeriod tp1 = new TimePeriod("2:18:42");
            Time t2 = new Time(17, 31, 59);
            TimePeriod tp2 = new TimePeriod("26:10:46");

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
            Time t1 = new Time(3, 15, 32);
            TimePeriod tp1 = new TimePeriod("2:18:42");
            Time t2 = new Time(17, 31, 59);
            TimePeriod tp2 = new TimePeriod("26:10:46");

            Time tt1 = t1 - tp1;
            Time tt2 = t2 - tp2;

            Assert.AreEqual("0:56:50", tt1.ToString());
            Assert.AreEqual("8:38:47", tt2.ToString());

        }

        #endregion

        #region Constructor TimePeriod================

        [TestMethod, TestCategory("Constructor TimePeriod")]
        public void Constructor_TimePeriod_Hour_Minutes_Seconds()
        {
            TimePeriod tp1 = new TimePeriod(11, 11, 11);
            TimePeriod tp2 = new TimePeriod(143, 54, 2);

            Assert.AreEqual("11:11:11", tp1.ToString());
            Assert.AreEqual("143:54:02", tp2.ToString());
        }

        [TestMethod, TestCategory("Constructor TimePeriod")]
        public void Constructor_TimePeriod_Hour_Minutes()
        {
            TimePeriod tp1 = new TimePeriod(11, 11);
            TimePeriod tp2 = new TimePeriod(143, 54);

            Assert.AreEqual("11:11:00", tp1.ToString());
            Assert.AreEqual("143:54:00", tp2.ToString());
        }
        [TestMethod, TestCategory("Constructor TimePeriod")]
        public void Constructor_TimePeriod_Seconds()
        {
            TimePeriod tp1 = new TimePeriod(6352);
            TimePeriod tp2 = new TimePeriod(4321);
            TimePeriod tp3 = new TimePeriod(236539);

            Assert.AreEqual("1:45:52", tp1.ToString());
            Assert.AreEqual("1:12:01", tp2.ToString());
            Assert.AreEqual("65:42:19", tp3.ToString());
        }
        [TestMethod, TestCategory("Constructor TimePeriod")]
        public void Constructor_TimePeriod_String()
        {
            TimePeriod tp1 = new TimePeriod("1:45:52");
            TimePeriod tp2 = new TimePeriod("1:12:01");
            TimePeriod tp3 = new TimePeriod("65:42:19");

            Assert.AreEqual("1:45:52", tp1.ToString());
            Assert.AreEqual("1:12:01", tp2.ToString());
            Assert.AreEqual(236539, tp3.Seconds);
        }

        #endregion

        #region TimePeriod Operators============

        [TestMethod, TestCategory("Equals TimePeriod")]
        public void TimePeriod_Equlas()
        {
            TimePeriod tp1 = new TimePeriod(35, 41, 28);
            TimePeriod tp2 = new TimePeriod("35:41:28");
            TimePeriod tp3 = new TimePeriod(87322);

            Assert.IsTrue(tp1.Equals(tp2));
            Assert.IsFalse(tp1.Equals(tp3));
        }

        [TestMethod, TestCategory("Equals TimePeriod")]
        public void TimePeriod_Operator_Equals()
        {
            TimePeriod tp1 = new TimePeriod(35, 41, 28);
            TimePeriod tp2 = new TimePeriod("35:41:28");
            TimePeriod tp3 = new TimePeriod(87322);

            Assert.IsTrue(tp1 == tp2);
            Assert.IsTrue(tp1 != tp3);
        }
        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Operator_Samller()
        {
            TimePeriod tp1 = new TimePeriod(35, 41, 28);
            TimePeriod tp2 = new TimePeriod("65:41:28");
            TimePeriod tp3 = new TimePeriod(872);

            Assert.IsTrue(tp1 < tp2);
            Assert.IsFalse(tp1 < tp3);
        }
        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Operator_Bigger()
        {
            TimePeriod tp1 = new TimePeriod(35, 41, 28);
            TimePeriod tp2 = new TimePeriod("25:41:28");
            TimePeriod tp3 = new TimePeriod(87673582);

            Assert.IsTrue(tp1 > tp2);
            Assert.IsFalse(tp1 > tp3);
        }
        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Operator_Smaller_Equals()
        {
            TimePeriod tp1 = new TimePeriod(35, 41, 28);
            TimePeriod tp2 = new TimePeriod("35:41:28");
            TimePeriod tp3 = new TimePeriod(87673582);

            Assert.IsTrue(tp1 <= tp2);
            Assert.IsTrue(tp1 <= tp3);
            Assert.IsFalse(tp3 <= tp1);
        }
        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Operator_Bigger_Equals()
        {
            TimePeriod tp1 = new TimePeriod(35, 41, 28);
            TimePeriod tp2 = new TimePeriod("35:41:28");
            TimePeriod tp3 = new TimePeriod(87673582);

            Assert.IsTrue(tp2 >= tp1);
            Assert.IsTrue(tp3 >= tp1);
            Assert.IsFalse(tp1 >= tp3);
        }

        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Operator_Plus()
        {
            TimePeriod tp1 = new TimePeriod(35, 41, 28);
            TimePeriod tp2 = new TimePeriod("35:41:28");
            TimePeriod tp3 = new TimePeriod(73582);

            TimePeriod ttp = tp1 + tp2;
            TimePeriod ttp0 = tp1 + tp3;

            Assert.AreEqual("71:22:56", ttp.ToString());
            Assert.AreEqual("56:07:50", ttp0.ToString());

        }
        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Method_Plus()
        {
            TimePeriod tp1 = new TimePeriod(35, 41, 28);
            TimePeriod tp2 = new TimePeriod("35:41:28");
            TimePeriod tp3 = new TimePeriod(73582);

            TimePeriod ttp = tp1 + tp2;
            TimePeriod ttp0 = tp1 + tp3;

            Assert.AreEqual(ttp, tp1 + tp2);
            Assert.AreEqual(ttp0, tp1 + tp3);

        }
        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Operator_Minus()
        {
            TimePeriod tp1 = new TimePeriod(35, 41, 28);
            TimePeriod tp2 = new TimePeriod("34:41:28");
            TimePeriod tp3 = new TimePeriod(73582);

            TimePeriod ttp = tp1 - tp2;
            TimePeriod ttp0 = tp1 - tp3;

            Assert.AreEqual("1:00:00", ttp.ToString());
            Assert.AreEqual("15:15:06", ttp0.ToString());

        }

        #endregion
    }
}
