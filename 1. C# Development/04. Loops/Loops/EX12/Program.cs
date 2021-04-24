using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX12
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Skriv in ett tal mellan 1-20: ");
            int N = int.Parse(Console.ReadLine());

            while (N < 1 | N > 20)
            {
                Console.WriteLine("Talet var antingen mindre än 1 eller strörre än 20, skriv ett nytt tal");
                Console.Write("Skriv in ett tal mellan 1-20: ");
                N = int.Parse(Console.ReadLine());
            }
            int c = 1;
            int u = 1;
            for (int i = 0; i < N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    Console.Write(c + " ");
                    c++;
                }

                c = 1+u;
                u++;
                
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
