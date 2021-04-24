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
            //Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one.

            int nr1 = 2;
            int nr2 = 3;
            int placeholder;

            Console.WriteLine("Tal1: {0} och tal2: {1}", nr1, nr2);

            if (nr1 > nr2)
            {
                placeholder = nr2;
                nr2 = nr1;
                nr1 = placeholder;
                Console.WriteLine("Tal1: {0} och tal2: {1}", nr1, nr2);
            }
            else
            {
                Console.WriteLine("Tal 1 var inte större än tal 2");
            }
            Console.ReadLine();

        }
    }
}
