using System;
using TimerLib;

namespace Timer
{
    class Program
    {
        static void Main(string[] args)
        {
            Time t1 = new Time(0, 20, 5);
            Time t2 = new Time(1, 10, 10);
            Time t3 = new Time("16:35:21");
            Console.WriteLine(t1.ToString());
            Console.WriteLine(t2.ToString()); 
            Console.WriteLine(t3.ToString());
            Console.WriteLine();

            TimePeriod tp1 = new TimePeriod(1, 10, 10);
            TimePeriod tp2 = new TimePeriod(112, 23, 59);
            TimePeriod tp3 = new TimePeriod(758652);
            TimePeriod tp4 = new TimePeriod("4:10:46");
            Console.WriteLine(tp1.ToString());
            Console.WriteLine(tp2.ToString());
            Console.WriteLine(tp3.ToString());
            Console.WriteLine(tp4.ToString());
            Console.WriteLine();

            Time tplus = t1 + tp1;
            Console.WriteLine(tplus.ToString());
            TimePeriod tpplus = tp1 + tp2;
            Console.WriteLine(tpplus.ToString());
            Console.WriteLine();

            t1.PlusTime(tp1);
            Console.WriteLine(t1.ToString());
            Console.WriteLine();

        }
    }
}
