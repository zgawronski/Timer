using System;

namespace TimerLib
{
    /// <summary>
    ///  struktura Time z zaimplementowaniem IEquatable<> i IComparable<>
    /// </summary>
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        /// <summary>
        /// dodanie zmiennych private byte i public ale readonly byte
        /// </summary>
        /// <param name="h"></param>
        /// <param name="m"></param>
        /// <param name="s"></param>
        /// <param name="Hours"></param>
        /// <param name="Minutes"></param>
        /// <param name="Seconds"></param>
        private byte h, m, s;
        public readonly byte Hours => h;
        public readonly byte Minutes => m;
        public readonly byte Seconds => s;

        #region Constructor Time==========================
        /// <summary>
        /// konstruktor dla byte
        /// </summary>
        /// <param name="h"></param>
        /// <param name="m"></param>
        /// <param name="s"></param>
        
        public Time(byte h, byte m = 0, byte s = 0) 
        {
            /// <returns>
            /// sprawdzenie poprawności formatu
            /// </returns>
            /// <exception cref="ArgumentException">Wyrzuca gdy użyty zostanie błędny format czasu</exception>
            if (h > 23 || h < 0 || m > 59 || m < 0 || s > 59 || s < 0) 
                throw new ArgumentException("Błędny format czasu");
            this.h = h;
            this.m = m;
            this.s = s;
        }

        /// <summary>
        /// konstruktor dla string
        /// </summary>
        /// <param name="time"></param>
        public Time(string time) 
        {
            string[] newT = time.Split(':');
            byte[] tabT = new byte[3] { 00, 00, 00 };
            for (int i = 0; i < newT.Length; i++)
            {
                tabT[i] = Byte.Parse(newT[i]);
            }
            h = tabT[0];
            m = tabT[1];
            s = tabT[2];

            /// <returns>
            /// sprawdzenie poprawności formatu
            /// </returns>
            /// <exception cref="ArgumentException">Wyrzuca gdy użyty zostanie błędny format czasu</exception>
            if (h > 23 || h < 0 || m > 59 || m < 0 || s > 59 || s < 0) 
                throw new ArgumentException("Błędny format czasu");
        }
        #endregion

        /// <summary>
        /// przeciążenie ToString()
        /// </summary>
        /// <returns> ustawia odpowiedni format wyświetlania czasu </returns>
        public override string ToString() 
        {
            return String.Format(
                "{0:00}:{1:00}:{2:00}",
                this.Hours, this.Minutes, this.Seconds);
        }
        #region Time Operators==================

        /// <summary>
        /// przeciążenie operatora ==
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns> sprawdza czy podane parametry są równe </returns>
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

        /// <summary>
        /// przeciążenie operatora !=
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns> sprawdza czy podane parametry są różne </returns>
        public static bool operator != (Time t1, Time t2) 
        {
            return !(t1 == t2);
        }

        /// <summary>
        /// przeciążenie operatora +
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="tp1"></param>
        /// <returns> dodaje parametr t1 do tp1 </returns>
        public static Time operator + (Time t1, TimePeriod tp1) 
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

        /// <summary>
        /// przeciążenie operatora +
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="tp1"></param>
        /// <returns> odejmuje parametr tp1 od t1 </returns>
        public static Time operator - (Time t1, TimePeriod tp1) 
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

        /// <summary>
        /// przeciążenie operatora <
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns> sprawdza czy parametr t1 jest mniejszy od t2 </returns>
        public static bool operator < (Time t1, Time t2) 
        {
            return t1.CompareTo(t2) < 0;
        }

        /// <summary>
        /// przeciążenie operatora >
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns> sprawdza czy parametr t1 jest większy od t2 </returns>
        public static bool operator > (Time t1, Time t2) 
        {
            return t1.CompareTo(t2) > 0;
        }

        /// <summary>
        /// przeciążenie operatora <=
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns> sprawdza czy parametr t1 jest mniejszy lub równy od t2 </returns>
        public static bool operator <= (Time t1, Time t2) 
        {
            return t1.CompareTo(t2) <= 0;
        }

        /// <summary>
        /// przeciążenie operatora >=
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns> sprawdza czy parametr t1 jest większy lub równy od t2 </returns>
        public static bool operator >= (Time t1, Time t2) 
        {
            return t1.CompareTo(t2) >= 0;
        }

        public bool Equals(Time other)
        {
            return Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds;
        }

        /// <summary>
        /// przeciążenie Equals()
        /// </summary>
        /// <param name="obj"></param>
        public override bool Equals(object obj)
        {
            return obj is Time other && Equals(other);
        }
        public int CompareTo(Time other)
        {
            var HoursCompare = Hours.CompareTo(other.Hours);
            if (HoursCompare != 0) return HoursCompare;
            var MinutesCompare = Minutes.CompareTo(other.Minutes);
            if (MinutesCompare != 0) return MinutesCompare;
            return Seconds.CompareTo(other.Seconds);
        }

        /// <summary>
        /// przeciążenie GetHashCode()
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }
        public static long ToSeconds(Time t1)
        {
            long timeSeconds = t1.h * 3600 + t1.m * 60 + t1.s;

            return timeSeconds;
        }

        /// <summary>
        /// metoda dodająca okres czasu
        /// </summary>
        /// <param name="tp1"></param>
        /// <returns> zwraca czas powiększony o wybrany okres czasu</returns>
        
        public void PlusTime(TimePeriod tp1)
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
        #endregion
    }
}
