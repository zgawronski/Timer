using System;
using TimerLib;

namespace Timer
{
    class Program
    {
        static void Main(string[] args)
        {
            Time t = new Time(15, 20, 5);
            Console.WriteLine(t.ToString());
        }
    }
}
