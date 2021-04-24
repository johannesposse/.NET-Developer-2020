using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> a = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i < 100000000; i++)
            {
                a.Add(rnd.Next(1, 101));
            }
            int count = 0; //hur många gånger
            int num = 0; //värdet
            StringBuilder s = new StringBuilder();
            a.Sort();
            DateTime start = DateTime.Now;
            for (int j = 0; j < a.Count; j++)
            {
                if (a[j] != num)
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
                }
                if (!s.ToString().Contains($"{num} --> {count} times\n"))
                    s.Append($"{num} --> {count} times\n");
            }
            DateTime end = DateTime.Now;
            double time = (end - start).TotalSeconds;
            time = Math.Round(time,0);
            Console.WriteLine("Score: " + time);
            Console.WriteLine(s);
            Console.ReadLine();
        }
    }
}
