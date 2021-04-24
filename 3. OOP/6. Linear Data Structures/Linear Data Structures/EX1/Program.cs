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
            List<uint> seq = new List<uint>();
            uint add = 0;
            while(true)
            {
                add = uint.Parse(Console.ReadLine());
                if (add != 0)
                    seq.Add(add);
                else
                    break;
            }
            uint sum = 0;
            uint av = 0;
            foreach (var s in seq)
            {
                sum += s;
            }
            uint a = (uint)seq.Count();
            av = sum / a;

            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Average: " + av);

            Console.ReadLine();
        }
    }
}
