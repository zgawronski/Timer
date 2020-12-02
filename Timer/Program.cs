using System;
using TimerLib;

namespace Timer
{
    class Program
    {
        static void Main(string[] args)
        {
            Time t1 = new Time(22, 20, 5);
            Time t2 = new Time(1, 10, 10);


            Console.WriteLine(t1.ToString());
        }
    }
}
