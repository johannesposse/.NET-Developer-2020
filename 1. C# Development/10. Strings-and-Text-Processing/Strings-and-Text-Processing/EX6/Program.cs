using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX6
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Skriv in max 20 tecken: ");
            string str = Console.ReadLine();

            Console.WriteLine(str.Length);

            while (str.Length > 19)
            {
                Console.WriteLine("För stort försök igen");
                str = Console.ReadLine();
            }

            StringBuilder s = new StringBuilder(str);

            while (s.Length <= 19)
            {
                int L = s.Length;
                s.Insert(L, "*");
            }

            str = s.ToString();

            

            Console.WriteLine(str);
            Console.WriteLine("01234567891123456789");

            Console.ReadLine();
        }
    }
}
