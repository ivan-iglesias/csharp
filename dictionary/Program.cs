using System;
using System.Collections.Generic;

namespace dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Ivan", "345624X");
            dict.Add("John", "345624X");
            dict.Add("Jane", "785482V");

            Print(dict);

            PrintWithVar(dict);

            if (dict.ContainsKey("Ivan"))
            {
                Console.WriteLine("OK");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Looping through dictionary.
        /// </summary>
        /// <param name="list"></param>
        static void Print(Dictionary<string, string> dict)
        {
            foreach (KeyValuePair<string, string> pair in dict)
            {
                Console.WriteLine("Key: {0} - Value: {1}", pair.Key.ToString(), pair.Value.ToString());
            }

            Console.WriteLine("----------------->");
        }

        /// <summary>
        /// Looping through dictionary.
        /// </summary>
        /// <param name="list"></param>
        static void PrintWithVar(Dictionary<string, string> dict)
        {
            foreach (var pair in dict)
            {
                Console.WriteLine("Key: {0} - Value: {1}", pair.Key.ToString(), pair.Value.ToString());
            }

            Console.WriteLine("----------------->");
        }
    }
}
