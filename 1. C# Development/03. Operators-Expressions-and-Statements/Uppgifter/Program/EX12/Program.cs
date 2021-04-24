using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX12
{
    class Program
    {
        static void Main(string[] args)
        {
            //We are given integer number n, value v (v=0 or 1) and a position p. 
            //Write a sequence of operators that modifies n to hold the value v at the position p from the binary representation of n.
            //Example: n = 5(00000101), p = 3, v = 1 🡪 13(00001101)
            //n = 5(00000101), p = 2, v = 0 🡪 1(00000001)

            int number, value, position, modifier;
            number = 5;
            position = 2;
            value = 0;

            modifier = number >> position  == 0 ? 1 : 0;
            int placeholder = modifier << position;
            string c = Convert.ToString(placeholder, 2);
            Console.WriteLine("Placeholder: " + c);
            number = placeholder + number;

            string b = Convert.ToString(number, 2);
            Console.WriteLine("Resultat: " + b.PadLeft(8,'0'));
            string a = Convert.ToString(modifier, 2);
            Console.WriteLine("Modifier: " + a);

            /*
            int modifier = number >> position;
            value = modifier;
            number = value;
            */

            //Console.WriteLine(modifier);

            //Console.WriteLine();
            //Console.WriteLine("Number: " + Convert.ToString(number).PadLeft(8,'0'));
            //Console.WriteLine("Position: " + Convert.ToString(position).PadLeft(8, '0'));
            //Console.WriteLine("Value: " + Convert.ToString(value).PadLeft(8, '0'));
            Console.ReadLine();

        }
    }
}
