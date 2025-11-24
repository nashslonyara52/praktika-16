using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public class Score
    {
        private int math;
        private int russian;
        private int physics;

        public int this[string subject]
        {
            get
            {
                return
                subject switch
                {
                    "Математика" => math,
                    "Русский" => russian,
                    "Физика" => physics,

                };
            }
            set
            {
                switch (subject)
                {
                    case "Математика":
                        math = value;
                        break;
                    case "Русский":
                        russian = value;
                        break;
                    case "Физика":
                        physics = value;
                        break;
                        
                }
            }
        }

        public override string ToString()
        {
            return $"Математика: {math}, Русский: {russian}, Физика: {physics}";
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                var sub = new Score();
                sub["Математика"] = 5;
                sub["Русский"] = 4;
                sub["Физика"] = 5;

                Console.WriteLine(sub["Математика"]);
                Console.WriteLine(sub);

            }
        }
    }
}
