using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    public class Money
    {
        public int Rubles { get; private set; }
        public int Kopecks { get; private set; }

        public Money(int rubles, int kopecks)
        {
            int totalKopecks = rubles * 100 + kopecks;
            if (totalKopecks < 0)
            {
                Rubles = totalKopecks / 100;
                Kopecks = totalKopecks % 100;
                if (Kopecks < 0)
                {
                    Rubles--;
                    Kopecks += 100;
                }
            }
            else
            {
                Rubles = totalKopecks / 100;
                Kopecks = totalKopecks % 100;
            }
        }

        public static Money operator +(Money a, Money b)
        {
            int totalKopecks = (a.Rubles + b.Rubles) * 100 + a.Kopecks + b.Kopecks;
            return new Money(0, totalKopecks); 
        }
        public static Money operator -(Money a, Money b)
        {
            int totalKopecks = (a.Rubles - b.Rubles) * 100 + a.Kopecks - b.Kopecks;
            return new Money(0, totalKopecks);
        }

        public override string ToString()
        {
            return $"{Rubles} руб {Kopecks} коп";
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                var m1 = new Money(47, 63);
                var m2 = new Money(9, 45);

                Console.WriteLine(m1 + m2);

                Console.WriteLine(m1 - new Money(47, 63));

            }
        }
    }

}
