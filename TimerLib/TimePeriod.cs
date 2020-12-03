using System;

namespace TimerLib
{
    /// <summary>
    ///  struktura TimePeriod z zaimplementowaniem IEquatable i IComparable
    /// </summary>
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        /// <summary>
        /// dodanie zmiennych prywatnego long, oraz publicznego, ale tylko do odczytu long
        /// </summary>
        /// <param name="sec"></param>
        /// <param name="Seconds"></param>
        private long sec;
        public readonly long Seconds => sec;

        #region Constructor TimePeriod================
        /// <summary>
        /// konstruktor dla byte
        /// </summary>
        /// <param name="h"></param>
        /// <param name="m"></param>
        /// <param name="s"></param>
        
        public TimePeriod(byte h, byte m, byte s = 0) 
        {
            /// <returns> 
            /// przeliczenie czasu na sekundy 
            /// </returns>
            this.sec = h * 3600 + m * 60 + s;
            /// <returns>
            /// sprawdzenie poprawności formatu
            /// </returns>
            /// <exception cref="ArgumentException">Wyrzuca gdy użyty zostanie błędny format czasu</exception>
            if (h <= 0 || m > 59 || m < 0 || s > 59 || s < 0)     
                throw new ArgumentException("Błędny format czasu");
            
        }
        /// <sumary>
        /// kostruktor dla long
        /// </sumary>
        public TimePeriod(long seconds) 
        {
            this.sec = seconds;
        }
        /// <sumary>
        /// konstruktor dla string
        /// </sumary>
        public TimePeriod(string timePeriod) 
        {
            string[] newT = timePeriod.Split(':');
            byte[] tabT = new byte[3] { 00, 00, 00 };
            for (int i = 0; i < newT.Length; i++)
            {
                tabT[i] = Byte.Parse(newT[i]);
            }
            this.sec = tabT[0] * 3600 + tabT[1] * 60 + tabT[2];

            /// <returns>
            /// sprawdzenie poprawności formatu
            /// </returns>
            /// <exception cref="ArgumentException">Wyrzuca gdy użyty zostanie błędny format czasu</exception>
            if (tabT[1] < 0 || tabT[1] > 59 || tabT[2] < 0 || tabT[2] > 59)     
                throw new ArgumentException("Błędny format czasu");
        }

        #endregion
        /// <summary>
        /// przeciążenie ToString()
        /// </summary>
        /// <returns> 
        /// ustawia odpowiedni format wyświetlania czasu
        /// </returns>
        public override string ToString() => $"{Seconds / 3600}:{Seconds / 60 % 60:D2}:{Seconds % 60:D2}";

        /// <summary>
        /// Metoda ToSeconds()
        /// </summary>
        /// <param name="t1"></param>
        /// <returns> przelicza godziny na sekundy </returns>
        public static long ToSeconds(Time t1)  
        {
            long timeSeconds = (t1.Hours * 3600) + (t1.Minutes * 60) + t1.Seconds;

            return timeSeconds;
        }
        #region TimePeriod Operators============
        public bool Equals(TimePeriod other)
        {
            return Seconds == other.Seconds;
        }

        /// <summary>
        /// przeciążenie Equals()
        /// </summary>
        /// <param name="obj"></param>
        public override bool Equals(object obj)
        {
            return obj is TimePeriod other && Equals(other);
        }

        /// <summary>
        /// przeciążenie GetHashCode()
        /// </summary>
        public override int GetHashCode()
        {
            return Seconds.GetHashCode();
        }
        public int CompareTo(TimePeriod other)
        {
            return Seconds.CompareTo(other.Seconds);
        }

        /// <summary>
        /// przeciążenie operatora ==
        /// </summary>
        /// <param name="tp1"></param>
        /// <param name="tp2"></param>
        /// <returns> sprawdza czy podane parametry są równe </returns>
        public static bool operator == (TimePeriod tp1, TimePeriod tp2) 
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

        /// <summary>
        /// przeciążenie operatora !=
        /// </summary>
        /// <param name="tp1"></param>
        /// <param name="tp2"></param>
        /// <returns> sprawdza czy podane parametry są różne </returns>
        public static bool operator != (TimePeriod tp1, TimePeriod tp2) 
        {
            return !(tp1 == tp2);
        }

        /// <summary>
        /// przeciążenie operatora <
        /// </summary>
        /// <param name="tp1"></param>
        /// <param name="tp2"></param>
        /// <returns> sprawdza czy parametr tp1 jest mniejszy od tp2 </returns>
        public static bool operator < (TimePeriod tp1, TimePeriod tp2) 
        {
            return tp1.CompareTo(tp2) < 0;
        }

        /// <summary>
        /// przeciążenie operatora >
        /// </summary>
        /// <param name="tp1"></param>
        /// <param name="tp2"></param>
        /// <returns> sprawdza czy parametr tp1 jest większy od tp2 </returns>
        public static bool operator > (TimePeriod tp1, TimePeriod tp2) 
        {
            return tp1.CompareTo(tp2) > 0;
        }

        /// <summary>
        /// przeciążenie operatora <=
        /// </summary>
        /// <param name="tp1"></param>
        /// <param name="tp2"></param>
        /// <returns> sprawdza czy parametr tp1 jest mniejszy lub równy od tp2 </returns>
        public static bool operator <= (TimePeriod tp1, TimePeriod tp2) 
        {
            return tp1.CompareTo(tp2) <= 0;

        }

        /// <summary>
        /// przeciążenie operatora >=
        /// </summary>
        /// <param name="tp1"></param>
        /// <param name="tp2"></param>
        /// <returns> sprawdza czy parametr tp1 jest większy lub równy od tp2 </returns>
        public static bool operator >= (TimePeriod tp1, TimePeriod tp2) 
        {
            return tp1.CompareTo(tp2) >= 0;
        }

        /// <summary>
        /// przeciążenie operatora +
        /// </summary>
        /// <param name="tp1"></param>
        /// <param name="tp2"></param>
        /// <returns> dodaje parametr tp1 do tp2 </returns>
        public static TimePeriod operator + (TimePeriod tp1, TimePeriod tp2) 
        {
            long s = tp1.Seconds + tp2.Seconds;

            return new TimePeriod(s);
        }

        /// <summary>
        /// przeciążenie operatora -
        /// </summary>
        /// <param name="tp1"></param>
        /// <param name="tp2"></param>
        /// <returns> odejmuje parametr tp2 od tp1 </returns>
        public static TimePeriod operator - (TimePeriod tp1, TimePeriod tp2) 
        {
            long s = tp1.sec - tp2.sec;
            if (s >= 0)
                return new TimePeriod(s);
            else
                throw new ArgumentException();
        }

        /// <summary>
        /// metoda dodająca okres czasu
        /// </summary>
        /// <param name="tp1"></param>
        /// <returns> zwraca okres czasu powiększony o inny okres czasu</returns>
        public void PlusTimePeriod(TimePeriod tp1)
        {
            long s = Seconds + tp1.Seconds;
            this.sec= s;

        }
        #endregion


    }
}
