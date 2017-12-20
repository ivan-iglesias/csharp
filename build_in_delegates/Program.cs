using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace build_in_delegates
{
    class Program
    {
        /*
         * Action: It can be used with methods that don’t return a value and have no parameter list.
         * 
         * Action<>: It can be used with methods that at least have one argument and don’t return a value.
         * 
         * Func<>: It can be used with methods that return a value and may have a parameter list.
         * 
         * Predicate<T>: Represents a method that takes one input parameter and returns a bool value on the
         * basis of some criteria.
         */

        static void Main(string[] args)
        {
            Func<string> info = Name;
            Console.WriteLine(info());

            // **************************************************************

            Func<string, string, string> fullName = FullName;
            Console.WriteLine(fullName("Ivan", "Iglesias"));

            // **************************************************************

            Func<int, int, int> calculate = Add;
            calculate += Min;

            foreach (Func<int, int, int> item in calculate.GetInvocationList())
            {
                Console.WriteLine(item(10, 5));
            }

            // **************************************************************

            Func<bool, int, string> func1 = (b, x) => $"{b} and {x}";
            Console.WriteLine(func1.Invoke(true, 7));

            // **************************************************************

            Func<int, int, bool> func2 = (a, b) => {
                a += 1;
                return a == b;
            };
            Console.WriteLine(func2.Invoke(3, 7));
            Console.WriteLine(func2.Invoke(6, 7));


            Console.ReadKey();
        }

        static string Name() => "Ivan";

        static string FullName(string name, string lastName) => $"{name} {lastName}";

        static int Add(int x, int y)
        {
            Console.Write("{0} + {1} = ", x, y);
            return (x + y);
        }

        static int Min(int x, int y)
        {
            Console.Write("{0} - {1} = ", x, y);
            return (x - y);
        }

    }
}
