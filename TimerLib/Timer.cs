using System;

namespace TimerLib
{
    public class Timer
    {
    }
    public struct Time
    {

        public byte Hours
        {
            get;
            private set;
        }
        public byte Minutes
        {
            get;
            private set;
        }
        public byte Seconds
        {
            get;
            private set;
        }
        public Time(uint h, uint m, uint s)
        {
            if (h > 23 || m > 59 || s > 59)
                throw new ArgumentException("Błędny format czasu");

            this.Hours = (byte)h;
            this.Minutes = (byte)m;
            this.Seconds = (byte)s;
        }
        public override string ToString()
        {
            return String.Format(
                "{0:00}:{1:00}:{2:00}",
                this.Hours, this.Minutes, this.Seconds);
        }
        public void AddHours(uint h)
        {
            this.Hours += (byte)h;
        }

        public void AddMinutes(uint m)
        {
            this.Minutes += (byte)m;
            while (this.Minutes > 59)
                this.Minutes -= 60;
            this.AddHours(1);
        }

        public void AddSeconds(uint s)
        {
            this.Seconds += (byte)s;
            while (this.Seconds > 59)
                this.Seconds -= 60;
            this.AddMinutes(1);
        }


    }

    public struct TimePeriod
    {

    }
}
