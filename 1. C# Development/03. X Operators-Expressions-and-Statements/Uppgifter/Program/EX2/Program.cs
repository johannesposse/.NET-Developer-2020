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
            //Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.
            int num1 = 70;
            bool check = num1 % 35 == 0 ? true : false;
            if (check == true)
            {
                Console.WriteLine(num1 + " är delbart med 7 och 5");
            }else
            {
                Console.WriteLine(num1 + " är inte delbart med 7 och 5");
            }
            Console.ReadLine();
            
        }
    }
}
