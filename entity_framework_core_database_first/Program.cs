using System;

namespace entity_framework_core_database_first
{
    class Program
    {
        /*
         * Actualmente con Entity Framework podemos elegir entre 3 enfoques diferentes para crear el modelo conceptual:
         * 
         * - Database First: El modelo conceptual se crea a partir de una base de datos existente.
         * - Model First: se crea el modelo conceptual y se genera la base de datos.
         * - Code First: nuevo a partir de EF 4.1. Permite mapear nuestras clases POCO a la base de datos.
         *   
         * https://dev.mysql.com/doc/index-other.html
         * 
         * 
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
