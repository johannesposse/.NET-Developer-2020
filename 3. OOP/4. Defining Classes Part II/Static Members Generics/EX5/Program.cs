using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX5
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int?> a = new GenericList<int?>(5);
            a.Add(5);
            a.Add(7);
            Console.WriteLine(a);
            GenericList<string> b = new GenericList<string>(5);
            b.Add("test");
            b.Add("min lilla ponny");
            Console.WriteLine(b);
            Console.WriteLine(b[1]="a");


            Console.ReadLine();
        }
    }
}
