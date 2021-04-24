using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Name("Johannes", "Posse"));
            Console.ReadLine();

        }

        static string Name (string firstName, string lastName)
        {
            string name = "Hello " + firstName + " " + lastName;
            return name;
        }
    }
}
