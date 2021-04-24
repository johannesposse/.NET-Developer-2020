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

            double num = 0;
            double result;

            try
            {
                if (num < 0)
                {
                    throw new ArgumentOutOfRangeException("Talet kan inte vara mindre än 0");
                }
                result = Math.Sqrt(num);
                Console.WriteLine("You entered a valid number. The sqrt of {0} is {1}", num, result);
            }
            catch (ArgumentOutOfRangeException fe)
            {
                Console.WriteLine(fe.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye");
            }

            Console.ReadLine();
        }
    }
}
