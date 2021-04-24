using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX11
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write an expression that extracts from a given integer i the value of a given bit number b. Example: i=5; b=2 🡪 value=1.
            int i, b, value;
            i = 5;
            b = 2;
            value = i >> b;
            string binary = Convert.ToString(i, 2);
            Console.WriteLine(i + " har ett värde av " + binary + " i binärt talsystem.");
            Console.WriteLine(value);
            Console.ReadLine();
        }
    }
}
