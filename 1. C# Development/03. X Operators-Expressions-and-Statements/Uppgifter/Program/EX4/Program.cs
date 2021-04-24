using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732 🡪 true.
            int num1 = 1325732;
            bool check = (num1 / 100) % 10 == 7 ? true : false;
            if (check == true)
            {
                Console.WriteLine("Den tredje siffran i " + num1 + " är en sjua");
            }else
            {
                Console.WriteLine("Den tredje siffran från höger i " + num1 + " är inte en sjua");
            }
            Console.ReadLine();
        }
    }
}
