using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX9
{
    class Program
    {
        static void Main(string[] args)
        {

            string str = "Microsoft announced its next generation PHP compiler today.\nIt is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
            Console.WriteLine(str);

            StringBuilder s = new StringBuilder(str);
            s.Replace("Microsoft", "*********");
            s.Replace("CLR", "***");
            s.Replace("PHP", "***");

            str = s.ToString();
            Console.WriteLine(str);

            Console.ReadLine();
        }
    }
}
