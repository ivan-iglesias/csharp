using System;
using System.Collections.Generic;
using System.Linq;

namespace list
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] oldNames = { "Taylor", "Ivan", "Jeffrey" };

            List<string> names = new List<string>();
            names.Add("Ivan");
            names.Add("John");
            names.Add("Jane");
            names.Add("Taylor");
            names.Add("John");
            names.Insert(0, "Jeffrey");


            // Remove the first found item from the list.
            names.Remove("John");

            Print(names);

            // Remove item by index.
            names.RemoveAt(0);

            // Array to list and sort.
            names = oldNames.ToList();
            names.Sort();

            Print(names);

            // Convert list to string.
            Console.WriteLine(string.Join(", ", names));

            // Check if an item exist in the List collection.
            Console.WriteLine(names.Contains("Ivan"));

            Console.ReadKey();
        }

        /// <summary>
        /// Print each list element's value using a foreach statement.
        /// </summary>
        /// <param name="list"></param>
        static void Print(List<string> list)
        {
            foreach (string item in list)
            {
                Console.WriteLine("Name: {0}", item);
            }

            Console.WriteLine("----------------->");
        }
    }
}
