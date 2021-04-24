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
            List<int> a = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            int count = 0; //hur många gånger
            int num = 0; //värdet
            for (int v = 0; v < 2; v++)
            {
                for (int j = 0; j < a.Count; j++)
                {
                    count = 0;
                    num = 0;
                    for (int i = 0; i < a.Count; i++)
                    {
                        if (a[j] == a[i])
                        {
                            count++;
                            num = a[j];
                        }
                    }
                    for (int k = 0; k < a.Count; k++)
                    {
                        if (count % 2 == 1 & a[k] == num)
                            a.RemoveAt(k);
                    }
                }
            }
            foreach (var c in a)
                Console.WriteLine(c);
            Console.ReadLine();
        }
    }
}
