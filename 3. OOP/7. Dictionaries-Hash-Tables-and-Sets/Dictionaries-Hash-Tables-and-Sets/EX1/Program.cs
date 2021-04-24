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
            var num = new double[] { 3,4,4,-2.5,3,3,4,3,-2.5};
            var occ = new Dictionary<double, double>();

            foreach (var n in num)
            {
                double count = 0;
                if (!occ.TryGetValue(n,out count))
                    count = 0;
                occ[n] = count + 1;
  
            }

            foreach(var o in occ)
                Console.WriteLine($"{o.Key}\t --> {o.Value.ToString()}");

            Console.ReadKey();
        }
    }
}
