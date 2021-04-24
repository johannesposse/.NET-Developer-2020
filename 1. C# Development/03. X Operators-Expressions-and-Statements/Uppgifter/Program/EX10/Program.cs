using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX10
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a boolean expression that returns if the bit at position p (counting from 0) in a given integer number v has value of 1. 
            //Example: v=5; p=1 🡪 false.
            int v = 5;
            int p = 1;
            bool bin = v >> p == 1 ? true : false;
            string check = Convert.ToString(v, 2);
            Console.WriteLine("Det binära talet av: " + v + " är " + check);
            if(bin == true)
            {
                Console.WriteLine("Bitpositionen " + p + " från höger har ett värde av 1 " + bin);
            }else
            {
                Console.WriteLine("Bitpositionen " + p + " från höger har inte ett värde av 1 " + bin);
            }
            Console.Read();



        }
    }
}
