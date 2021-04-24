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
            int n = 4;
            int tal = 1;
            int counter = 0;
            int[,] arrays = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arrays[counter, i] = tal;
                    tal++;
                    counter++;

                }
                counter = 0;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arrays[i,j] + " ");

                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
