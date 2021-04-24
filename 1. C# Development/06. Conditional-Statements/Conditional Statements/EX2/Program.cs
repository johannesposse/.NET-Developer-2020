using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.

            int nr1, nr2, nr3;
            string one, two, three, to;
            nr1 = -5;
            nr2 = -7;
            nr3 = 500;
            bool sign = true;

            int result = (nr1 * nr2 * nr3);
            Console.WriteLine(result);

            if (nr1 < 0)
            {
                one = "-";
            }
            else
                one = "+";

            if (nr2 < 0)
            {
                two = "-";
            }
            else
                two = "+";

            if (nr3 < 0)
            {
                three = "-";
            }
            else
                three = "+";

            to = one + two + three;
            
            if (to == "---" ^ to == "--+" ^ to =="-+-" ^ to == "+--")
            {
                sign = false;
                Console.WriteLine("-");
            }else
                Console.WriteLine("+");
                

            
            Console.ReadLine();
        }
    }
}
