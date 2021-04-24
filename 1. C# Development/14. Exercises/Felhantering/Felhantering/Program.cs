using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felhantering
{
    class Program
    {
        static void Main(string[] args)
        {

            MinMaxValue ex = new MinMaxValue(1,10);

            Console.WriteLine("Max " + ex.Max);
            Console.WriteLine("Min " + ex.Min);

            try
            {
                ex.Value = 20;
            }
            catch (ArgumentOutOfRangeException fe)
            {
               Console.WriteLine(fe.Message);
            }

            try
            {
                ex.Value = 5;
            }
            catch (ArgumentOutOfRangeException fe)
            {
                Console.WriteLine(fe.Message);
            }

            Console.WriteLine(ex.Value);



           
            Console.ReadLine();


        }
    }
}
