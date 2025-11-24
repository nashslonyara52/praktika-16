using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    public class Time
    {
        private int hours;
        private int minutes;
        private int seconds;

        public Time(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public int Hours
        {
            get { return hours; }
            set
            {
                if (value < 0 || value > 23)
                    throw new ArgumentException("Часы должны быть от 0 до 23");
                hours = value;
            }
        }

        public int Minutes
        {
            get { return minutes; }
            set
            {
                if (value < 0 || value > 59)
                    throw new ArgumentException("Минуты должны быть от 0 до 59");
                minutes = value;
            }
        }

        public int Seconds
        {
            get { return seconds; }
            set
            {
                if (value < 0 || value > 59)
                    throw new ArgumentException("Секунды должны быть от 0 до 59");
                seconds = value;
            }
        }

        public object HashCode { get; private set; }

        // Перегрузка оператора >
        public static bool operator >(Time t1, Time t2)
        {
            if (t1.hours != t2.hours)
                return t1.hours > t2.hours;
            if (t1.minutes != t2.minutes)
                return t1.minutes > t2.minutes;
            return t1.seconds > t2.seconds;
        }

        public static bool operator <(Time t1, Time t2)
        {
            return !(t1 > t2) && !(t1 == t2);
        }

        public static bool operator ==(Time t1, Time t2)
        {
            if (ReferenceEquals(t1, t2)) return true;
            if (t1 is null || t2 is null) return false;
            return t1.hours == t2.hours && t1.minutes == t2.minutes && t1.seconds == t2.seconds;
        }

        public static bool operator !=(Time t1, Time t2)
        {
            return !(t1 == t2);
        }

        public int this[int index]
        {
            get
            {
                return index switch
                {
                    0 => hours,
                    1 => minutes,
                    2 => seconds,
                    _ => throw new IndexOutOfRangeException("Индекс должен быть 0, 1 или 2")
                };
            }
            set
            {
                switch (index)
                {
                    case 0: Hours = value; break;
                    case 1: Minutes = value; break;
                    case 2: Seconds = value; break;
                    default: throw new IndexOutOfRangeException("Индекс должен быть 0, 1 или 2");
                }
            }
        }

        public override string ToString()
        {
            return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }

        public override bool Equals(object obj)
        {
            return this == (obj as Time);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(hours, minutes, seconds);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {


            var t1 = new Time(14, 35, 9);
            var t2 = new Time(9, 10, 5);

            Console.WriteLine($"t1 = {t1}");
            Console.WriteLine($"t2 = {t2}");
            Console.WriteLine($"t1 > t2 = {t1 > t2}"); 
            Console.WriteLine($"t1[1] = {t1[1]}"); 

            t1[2] = 59;
            Console.WriteLine($"После t1[2] = 59: {t1}"); 
        }
    }
}