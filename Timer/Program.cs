using System;
using TimerLib;

namespace Timer
{
    class Program
    {
        static void Main(string[] args)
        {
            // użycie konstruktora Time() do wprowadzenia czasu dla byte
            Time t1 = new Time(0, 20, 5);
            Time t2 = new Time(1, 10, 10);
            // użycie konstruktora Time() do wprowadzenia czasu dla string
            Time t3 = new Time("16:35:21");

            // wyświetlenie rezultatu użycia konstruktora Time() dla byte
            Console.WriteLine(t1.ToString());
            Console.WriteLine(t2.ToString());
            // wyświetlenie rezultatu użycia konstruktora Time() dla string
            Console.WriteLine(t3.ToString());
            Console.WriteLine();

            // użycie konstruktora TimePeriod()
            TimePeriod tp1 = new TimePeriod(1, 10, 10);
            TimePeriod tp2 = new TimePeriod(112, 23, 59);
            TimePeriod tp3 = new TimePeriod(758652);
            TimePeriod tp4 = new TimePeriod("4:10:46");
            // wyświetlenie rezultatu użycia konstruktora TimePeriod()
            Console.WriteLine(tp1.ToString());
            Console.WriteLine(tp2.ToString());
            Console.WriteLine(tp3.ToString());
            Console.WriteLine(tp4.ToString());
            Console.WriteLine();

            // dodanie odcinka czasu do czasu (TimePeriod do Time)
            Time tplus = t1 + tp1;
            Console.WriteLine(tplus.ToString());

            // dodanie odcinka czasu do odcinka czasu (TimePeriod do TimePeriod
            TimePeriod tpplus = tp1 + tp2;
            Console.WriteLine(tpplus.ToString());
            Console.WriteLine();

            // odjęcie okresu czasu od czasu (TimePeriod od Time)
            Time tminus = t3 - tp1;
            Console.WriteLine(tminus.ToString());
            Console.WriteLine();


            //odjęcie okresu czasu od okresu czasu (TimePeriod od TimePeriod)
            TimePeriod tpminus = tp2 - tp1;
            Console.WriteLine(tpminus.ToString());
            Console.WriteLine();

            // użycie metody powiększenia czasu o okres czasu (Time o TimePeriod)
            t1.PlusTime(tp1);
            Console.WriteLine(t1.ToString());
            Console.WriteLine();

            // sprawdzenie czy czas 1 jest większy od czasu 2
            Console.WriteLine(t1 > t2);
            Console.WriteLine();

            // sprawdzenie czy czas 1 jest mniejszy od czasu 2
            Console.WriteLine(t1 < t2);
            Console.WriteLine();

            // sprawdzenie czy czas 1 jest równy czasowi 2
            Console.WriteLine(t1 == t2);
            Console.WriteLine();

            // sprawdzenie czy czas 1 jest różny od czasu 2
            Console.WriteLine(t1 != t2);
            Console.WriteLine();

            // sprawdzenie czy okres czasu 1 jest większy od okresu czasu 2
            Console.WriteLine(tp1 > tp2);
            Console.WriteLine();

            // sprawdzenie czy okres czasu 1 jest mniejszy od okresu czasu 2
            Console.WriteLine(tp1 < tp2);
            Console.WriteLine();

            // sprawdzenie czy okres czasu 1 jest równy okresowi czasu 2
            Console.WriteLine(tp1 == tp2);
            Console.WriteLine();

            // sprawdzenie czy okres czasu 1 jest różny od okresu czasu 2
            Console.WriteLine(tp1 != tp2);
            Console.WriteLine();

        }
    }
}
