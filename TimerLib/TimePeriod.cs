using System;

namespace TimerLib
{
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        
        private long sec;
        public readonly long Seconds => sec;

        #region Constructor TimePeriod================

        public TimePeriod(byte h, byte m, byte s = 0) // konstruktor byte
        {

            this.sec = h * 3600 + m * 60 + s; // przeliczenie czasu na sekundy
            
            if (h <= 0 || m > 59 || m <= 0 || s > 59 || s <= 0)     
                throw new ArgumentException("Błędny format czasu"); // sprawdzenie poprawności formatu
        }
        public TimePeriod(long seconds) // kostruktor long
        {
            this.sec = seconds;
        }

        public TimePeriod(string timePeriod) // kosntruktor string
        {
            string[] newT = timePeriod.Split(':');
            byte[] tabT = new byte[3] { 00, 00, 00 };
            for (int i = 0; i < newT.Length; i++)
            {
                tabT[i] = Byte.Parse(newT[i]);
            }
            this.sec = tabT[0] * 3600 + tabT[1] * 60 + tabT[2];

           if (tabT[1] <= 0 || tabT[1] > 59 || tabT[2] <= 0 || tabT[2] > 59)     
                throw new ArgumentException("Błędny format czasu");
        }

        #endregion
        public override string ToString() => $"{Seconds / 3600}:{Seconds / 60 % 60:D2}:{Seconds % 60:D2}";  // ustawia odpowiedni format wyświetlania czasu

        public static long ToSeconds(Time t1)  // przelicza godziny na sekundy
        {
            long timeSeconds = (t1.Hours * 3600) + (t1.Minutes * 60) + t1.Seconds;

            return timeSeconds;
        }
        public bool Equals(TimePeriod other)
        {
            return Seconds == other.Seconds;
        }

        public override bool Equals(object obj)
        {
            return obj is TimePeriod other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Seconds.GetHashCode();
        }
        public int CompareTo(TimePeriod other)
        {
            return Seconds.CompareTo(other.Seconds);
        }
        #region TimePeriod Operators============
        public static bool operator == (TimePeriod tp1, TimePeriod tp2) // przeciążenie operatora ==
        {

            if (TimePeriod.ReferenceEquals(tp1, null))
            {
                if (TimePeriod.ReferenceEquals(tp2, null))
                {
                    return true;
                }
                return false;
            }

            return tp1.Equals(tp2);
        }

        public static bool operator != (TimePeriod tp1, TimePeriod tp2) // przeciążenie operatora !=
        {
            return !(tp1 == tp2);
        }

        public static bool operator < (TimePeriod tp1, TimePeriod tp2) // przeciążenie operatora <
        {
            return tp1.CompareTo(tp2) < 0;
        }

        public static bool operator > (TimePeriod tp1, TimePeriod tp2) // przeciążenie operatora >
        {
            return tp1.CompareTo(tp2) > 0;
        }

        public static bool operator <= (TimePeriod tp1, TimePeriod tp2) // przeciążenie operatora <=
        {
            return tp1.CompareTo(tp2) <= 0;

        }

        public static bool operator >= (TimePeriod tp1, TimePeriod tp2) // przeciążenie operatora >=
        {
            return tp1.CompareTo(tp2) >= 0;
        }

        public static TimePeriod operator + (TimePeriod tp1, TimePeriod tp2) // przeciążenie operatora +
        {
            long s = tp1.Seconds + tp2.Seconds;

            return new TimePeriod(s);
        }
        public static TimePeriod operator - (TimePeriod tp1, TimePeriod tp2) // przeciążenie operatora -
        {
            long s = tp1.sec - tp2.sec;
            if (s >= 0)
                return new TimePeriod(s);
            else
                throw new ArgumentException();
        }

        public void PlusTimePeriod(TimePeriod tp1)
        {
            long s = Seconds + tp1.Seconds;
            this.sec= s;

        }
        #endregion


    }
}
