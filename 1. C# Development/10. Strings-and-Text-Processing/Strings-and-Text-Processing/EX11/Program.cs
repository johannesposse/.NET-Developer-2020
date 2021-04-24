using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Skriv in ett nummer: ");
            int num = int.Parse(Console.ReadLine());
            string s;

            
            Console.WriteLine("Number {0}", num);
            s = num.ToString("X");
            Console.WriteLine("Hexadecimal {0}", s.PadLeft(15));
            s = num.ToString("D3");
            Console.WriteLine("Decimal {0}", s.PadLeft(15));
            s = num.ToString("P2");
            Console.WriteLine("Percentage {0}", s.PadLeft(15));

            Console.ReadLine();
        }
    }
}
