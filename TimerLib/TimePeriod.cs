using System;

namespace TimerLib
{
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        private byte h, m, s;
        public readonly byte Hours => h;
        public readonly byte Minutes => m;
        public readonly byte Seconds => s;

        public TimePeriod(byte h, byte m, byte s)
        {
            if (h > 23 || m > 59 || s > 59)
                throw new ArgumentException("Błędny format czasu");

            this.h= h;
            this.m = m;
            this.s = s;
        }
        public override string ToString()
        {
            return String.Format(
                "{0:00}:{1:00}:{2:00}",
                this.Hours, this.Minutes, this.Seconds);
        }
        public void AddHours(byte h)
        {
            this.h += h;
        }

        public void AddMinutes(byte m)
        {
            this.m += (byte)m;
            while (this.m > 59)
                this.m -= 60;
            this.AddHours(1);
        }

        public void AddSeconds(byte s)
        {
            this.s += (byte)s;
            while (this.s > 59)
                this.s -= 60;
            this.AddMinutes(1);
        }
        public static long ToSeconds(Time t1)
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
    }
}
