using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yield
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Rocket> rockets = TestData();

            List<Rocket> filtered = GetValuesGreaterThan20(rockets);
            Print(filtered);

            List<Rocket> filteredYield = GetValuesGreaterThan10(rockets).ToList();
            Print(filteredYield);

            Console.ReadKey();
        }


        /// <summary>
        /// The rockets faster than 20 using yield. To avoid the usage of a temporary collection.
        /// </summary>
        /// <param name="Rockets"></param>
        /// <returns></returns>
        static public IEnumerable<Rocket> GetValuesGreaterThan10(List<Rocket> Rockets)
        {
            foreach (var rocket in Rockets)
            {
                if (rocket.Speed > 10)
                    yield return rocket;
            }
        }

        /// <summary>
        /// The the rockets faster than 20
        /// </summary>
        /// <param name="Rockets"></param>
        /// <returns></returns>
        static public List<Rocket> GetValuesGreaterThan20(List<Rocket> Rockets)
        {
            List<Rocket> tempResult = new List<Rocket>();

            foreach (var rocket in Rockets)
            {
                if (rocket.Speed > 20)
                    tempResult.Add(rocket);
            }
            return tempResult;
        }

        /// <summary>
        /// Test data
        /// </summary>
        /// <returns></returns>
        static List<Rocket> TestData()
        {
            return new List<Rocket>() {
                new Rocket{ ID = 0, Builder = "NASA", Target = "Moon", Speed=7.8},
                new Rocket{ ID = 1, Builder = "NASA", Target = "Mars", Speed=10.9},
                new Rocket{ ID = 2, Builder = "NASA", Target = "Kepler-452b", Speed=42.1},
                new Rocket{ ID = 3, Builder = "NASA", Target = "N/A", Speed=0},
                new Rocket{ ID = 4, Builder = "NASA", Target = "Jupiter", Speed=30}
            };
        }

        /// <summary>
        /// Looping through list.
        /// </summary>
        /// <param name="list"></param>
        static void Print(List<Rocket> list)
        {
            foreach (Rocket item in list)
            {
                Console.WriteLine("Target: {0} Speed: {1}", item.Target, item.Speed);
            }

            Console.WriteLine("----------------->");
        }
    }

    /// <summary>
    /// Rocket class
    /// </summary>
    public class Rocket
    {
        public int ID { get; set; }
        public string Builder { get; set; }
        public string Target { get; set; }
        public double Speed { get; set; }
    }
}
