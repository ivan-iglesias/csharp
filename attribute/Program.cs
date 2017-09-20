using System;
using System.Diagnostics;

// An attribute is a declarative tag that is used to convey information (metadata)
// to runtime about the behaviors of various elements like classes, methods, structures,
// enumerators, assemblies etc. in your program.

namespace attribute
{
    public class Myclass
    {
        [Conditional("DEBUG")]
        public static void Message(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    class Program
    {
        #if DEBUG
            public const String ENVIRONMENT = "Development";
        #else
            public const String ENVIRONMENT = "Production";
        #endif

        static void FunctionNew()
        {
            Myclass.Message("In new function.");
        }

        [Obsolete("Don't use FunctionOld, use FunctionNew instead", false)]
        static void FunctionOld()
        {
            Myclass.Message("In old function.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ENVIRONMENT);
            Myclass.Message("In Main function.");
            FunctionNew();
            FunctionOld();
            Console.ReadKey();
        }
    }
}
