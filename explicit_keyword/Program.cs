using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace explicit_keyword
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use the explicit keyword to define the conversion of one business entity to another.
            // The conversion method will be invoked when the conversion is requested in code.

            ExternalEntity entity = new ExternalEntity() {
                Id = 1001,
                FirstName = "Dave",
                LastName = "Johnson"
            };

            MyEntity convertedEntity = (MyEntity)entity;

            Console.WriteLine("ID: {0} FullName: {1}", convertedEntity.Id, convertedEntity.FullName);

            Console.ReadKey();
        }
    }

    class MyEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public static explicit operator MyEntity(ExternalEntity externalEntity)
        {
            return new MyEntity()
            {
                Id = externalEntity.Id,
                FullName = externalEntity.FirstName + " " + externalEntity.LastName
            };
        }
    }

    class ExternalEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
