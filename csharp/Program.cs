using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Initializing and assigning values to an Array

            //string[] names = new string[10];
            //names[0] = "Ivan";

            //string[] names = { "Ivan", "John", "Jane" };

            //string[] names = new string[3] { "Ivan", "John", "Jane" };

            //string[] names = new string[] { "Ivan", "John", "Jane" };

            #endregion

            string[] names = { "Ivan", "John", "Jane", "Taylor", "Jeffrey" };

            // Copy an array variable into another target array variable.
            // Both the target and source point to the same memory location
            string[] oldNames = names;
            oldNames[0] = "Ivan Iglesias";

            // Reverses the sequence of the elements.
            Array.Reverse(names);

            // Sorts the elements.
            Array.Sort(oldNames);

            ForArray(names);
            ForeachArray(oldNames);

            Console.ReadKey();
        }

        /// <summary>
        /// Output each array element's value using a for loop.
        /// </summary>
        /// <param name="array"></param>
        static void ForArray(string[] array)
        {
            int i;

            for (i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Name ({0}): {1}", i, array[i]);
    
            }
        }

        /// <summary>
        /// Output each array element's value using a foreach statement.
        /// </summary>
        /// <param name="array"></param>
        static void ForeachArray(string[] array)
        {
            foreach (string item in array)
            {
                Console.WriteLine("Name: {0}", item);

            }
        }
    }
}
