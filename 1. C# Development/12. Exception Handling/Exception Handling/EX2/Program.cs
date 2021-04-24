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

            ReadNumber(1,10);

            Console.ReadLine();

        }

        static int ReadNumber (int start, int end)
        {
            Console.WriteLine("Enter a number between {0}-{1}", start, end);

            int result = 0;

            try
            {

                if ( int.TryParse(Console.ReadLine(), out result))
                {
                    if (result < start || result > end)
                    {
                        throw new ArgumentOutOfRangeException("The number was bigger than " + start + " and or smaller than " + end);
                    }
                    else
                    {
                        Console.WriteLine("{0} var emellan {1}-{2}", result, start, end);
                        return result;
                    }
                }
                else
                {
                    throw new FormatException("Skriv in en siffra");
                }   
                
            }
            catch (ArgumentOutOfRangeException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }

            return -1;
            
            
        }
    }
}
