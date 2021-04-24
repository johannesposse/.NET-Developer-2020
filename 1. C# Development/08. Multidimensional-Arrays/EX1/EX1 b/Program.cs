using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1_b
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            int tal = 1;
            int counter = 0;
            int counter2 = n-1;
            int column = 0;
            int column2 = 1;
            int[,] arrays = new int[n, n];

            for (int i = 0; i < (n/2); i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arrays[counter, column] = tal;
                    tal++;
                    counter++;
                }
                    column = column + 2;

                for (int k = 0; k <n; k++)
                {
                    
                    arrays[counter2, column2] = tal ;
                    tal++;
                    counter2--;
                }

                column2 = column2 + 2;
                counter = 0;
                counter2 = n-1;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("[{0}] ",arrays[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
