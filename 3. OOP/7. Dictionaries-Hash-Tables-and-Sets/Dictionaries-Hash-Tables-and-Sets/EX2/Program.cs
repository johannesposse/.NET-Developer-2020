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
            var text = new String[] { "C#", "SQL", "PHP","PHP", "SQL", "SQL" };
            var odd = new Dictionary<string, int>();

            foreach(var t in text)
            {
                int count;
                if(!odd.TryGetValue(t, out count))
                    count = 0;
                odd[t] = count + 1;
            }

            foreach(var o in odd)
            {
                if (o.Value % 2 == 1)
                    Console.WriteLine(o.Key);
            }

            Console.ReadLine();
        }
    }
}
