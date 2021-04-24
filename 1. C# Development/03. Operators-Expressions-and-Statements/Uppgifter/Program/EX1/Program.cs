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
            //Write an expression that checks if given integer is odd or even.
            int odd = 21;
            int even = 30;
            int resultOdd = odd % 2;
            int resultEven = even % 2;
            if (resultOdd == 1)
            {
                Console.WriteLine("Talet " + odd + " är ojämt");
            }else
            {
                Console.WriteLine("Talet " + odd + " är jämt");
            }
            if (resultEven == 0)
            {
                Console.WriteLine("Talet " + even + " är jämt");
            }
            else
            {
                Console.WriteLine("Talet " + even + " är ojämt");
            }
            Console.ReadLine();
        }
    }
}
