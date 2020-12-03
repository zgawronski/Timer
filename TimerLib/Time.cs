using System;

namespace TimerLib
{
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        
        private byte h, m, s;
        public readonly byte Hours => h;
        public readonly byte Minutes => m;
        public readonly byte Seconds => s;

        public Time(byte h, byte m, byte s)
        {
            if (h > 23 || h <= 0 || m > 59 || m <= 0 || s > 59 || s <= 0) // sprawdza poprawność formatu czasu
                throw new ArgumentException("Błędny format czasu");

            this.h = h;
            this.m = m;
            this.s = s;
        }
        public override string ToString() // ustawia odpowiedni format wyświetlania czasu
        {
            return String.Format(
                "{0:00}:{1:00}:{2:00}",
                this.Hours, this.Minutes, this.Seconds);
        }
        public static bool operator == (Time t1, Time t2)
        {

            if (Time.ReferenceEquals(t1, null))
            {
                if (Time.ReferenceEquals(t2, null))
                {
                    return true;
                }
                return false;
            }

            return t1.Equals(t2);
        }

        public static bool operator != (Time t1, Time t2)
        {
            return !(t1 == t2);
        }


        public static Time operator +(Time t1, TimePeriod tp1)
        {
            long sec = ToSeconds(t1) + tp1.Seconds;

            byte h;
            if (sec / 3600 > 23)
            {
                h = (byte)((sec / 3600) % 24);
            }
            else
            {
                h = (byte)((sec / 3600));
            }

            byte m = (byte)((sec / 60) % 60);
            byte s = (byte)(sec % 60);



            return new Time(h, m, s);
        }
        public void Time_Plus(TimePeriod tp1)
        {
            long sec = Hours * 3600 + Minutes * 60 + Seconds + tp1.Seconds;

            byte h;
            if (sec / 3600 > 23)
            {
                h = (byte)((sec / 3600) % 24);
            }
            else
            {
                h = (byte)((sec / 3600));
            }

            byte m = (byte)((sec / 60) % 60);
            byte s = (byte)(sec % 60);


            this.h = h;
            this.m = m;
            this.s = s;
        }
        public static Time operator -(Time t1, TimePeriod tp1)
        {
            long sec = ToSeconds(t1) - tp1.Seconds;
            if (sec < 0)
                sec *= -1;

            byte h;
            if (sec / 3600 < 0)
            {
                h = (byte)((sec / 3600) + 24);
            }
            else
            {
                h = (byte)((sec / 3600));
            }

            byte m = (byte)((sec / 60) % 60);
            byte s = (byte)(sec % 60);



            return new Time(h, m, s);

        }
        public static bool operator < (Time t1, Time t2)
        {
            return t1.CompareTo(t2) < 0;
        }

        public static bool operator > (Time t1, Time t2)
        {
            return t1.CompareTo(t2) > 0;
        }

        public static bool operator <= (Time t1, Time t2)
        {
            return t1.CompareTo(t2) <= 0;
        }

        public static bool operator >= (Time t1, Time t2)
        {
            return t1.CompareTo(t2) >= 0;
        }

        public bool Equals(Time other)
        {
            return Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds;
        }
        public override bool Equals(object obj)
        {
            return obj is Time other && Equals(other);
        }
        public int CompareTo(Time other)
        {
            var HoursComparsion = Hours.CompareTo(other.Hours);
            if (HoursComparsion != 0) return HoursComparsion;
            var MinutesComparsion = Minutes.CompareTo(other.Minutes);
            if (MinutesComparsion != 0) return MinutesComparsion;
            return Seconds.CompareTo(other.Seconds);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }
        public static long ToSeconds(Time t1)
        {
            long timeSeconds = t1.h * 3600 + t1.m * 60 + t1.s;

            return timeSeconds;
        }
    }
}
