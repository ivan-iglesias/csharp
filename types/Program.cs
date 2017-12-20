using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace types
{
    /*
     * Enums are useable to use constant values.
     * Enums are readable and to give just information that is required in code.
     * Enums are strongly typed. Therefore, an enum of one type cannot be implicitly
     * assigned to an enum of another type.
     */
    enum JapanseColors { Ao = 1, Aka, Midori, Kiro }

    /*
     * Enum supports the following types for its constant’s values:
     * byte, sbyte, short, ushort, int, uint, long, ulong
     * To minimize the memory storage required to initialize an enum.
     */
    enum JapanseNames : byte { Ryu = 1, Madoka, Akira, Misae }

    /*
     * Struct is used to encapsulate the attribute and behavior of an entity.
     * It’s used to define those objects which hold small memory struct Vector.
     */
    struct Vector
    {
        public int x;
        public int y;
    }

    /*
     * Constructor is optional in struct but if included it must not be parameterless.
     * Constructor can be overload but each overloaded constructor must initialize all data members.
     * Data members or fields cannot be initialized in the struct body.
     */
    struct VectorWithConstructor
    {
        public VectorWithConstructor(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int x;
        public int y;
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            JapanseColors color = JapanseColors.Midori;
            int index = (int)color;

            Console.WriteLine($"Hello {JapanseNames.Ryu}!, your favorite Japanese color is {color}({index}).");

            Vector vector = new Vector
            {
                x = 7,
                y = 14
            };

            VectorWithConstructor vectorWithConstructor = new VectorWithConstructor(2, 3);
            vector.x = 7;
            vector.y = 14;

            Console.WriteLine($"X: {vector.x}, Y: {vector.y}");
            Console.WriteLine($"X: {vectorWithConstructor.x}, Y: {vectorWithConstructor.y}");

            Console.ReadKey();
        }
    }
}
