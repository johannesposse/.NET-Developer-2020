using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.
            //förstår inte exakt hur detta funkar, har inte riktigt koll på hur Primtalfunkar heller så
            int n = 4;
            if (n == 0 || n == 1)
            {
                Console.WriteLine(n + " är inte ett primtal");
            }else
            {
                for (int a = 2; a <= n / 2; a++)
                {
                    if (n % a == 0)
                    {
                        Console.WriteLine(n + " är inte ett primtal");
                        
                    }else
                    {
                        Console.WriteLine(n + " är ett primtal");
                        break;
                        
                    }
                }

            }


            /*
            bool prime = (n % 2) == 0 & (n % n) == 0 ? true : false;
            if (prime == true)
            {
                Console.WriteLine(n + " är ett primtal");
            }else
            {
                Console.WriteLine(n + " är inte ett primtal");
            }
            */
            Console.ReadLine();

        }
    }
}
