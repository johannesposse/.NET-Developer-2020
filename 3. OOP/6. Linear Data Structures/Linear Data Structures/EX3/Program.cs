using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> a = new List<int>();
            int add = 0;
            while (true)
            {
                try
                {
                    add = int.Parse(Console.ReadLine());
                }
                catch
                {
                    break;
                }
                    a.Add(add);
            }
            a.Sort();
            foreach(var b in a)
            {
                Console.WriteLine(b);
            }
            Console.ReadLine();
        }
    }
}
