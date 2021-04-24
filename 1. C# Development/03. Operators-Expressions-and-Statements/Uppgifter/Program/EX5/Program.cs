using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EX5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.
            int num1 = 4; // 0100
            string binary = Convert.ToString(num1, 2);
            Console.WriteLine(num1 + " har värdet " + binary + " i binärt talsystem");
            
            bool check = num1 >> 2 == 1 ? true : false;
            if (check == true)
            {
                Console.WriteLine("Bit 3 i " + binary + " har värdet 1");
            }else
            {
                Console.WriteLine("Bit 3 i " + binary + " har inte värdet 1");
            }
            Console.ReadLine();
        }
    }
}
