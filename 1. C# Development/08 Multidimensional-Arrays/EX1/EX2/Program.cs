using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2
{
    class Program
    {
        static void Main(string[] args)
        {

            //ej färdig

            int n = 6;
            int m = 6;
            int[,] arrays = new int[n, m];
            Random randomerare = new Random();
            int j;
            
            //matar in siffror i arrays
            for (int i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    int num = randomerare.Next(1, 10);
                    arrays[i, j] = num;
                }

                j = 0;
            }

            //skriver ut arrays i en rektangel
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < m; k++)
                {
                    Console.Write("[{0}] ", arrays[i, k]);
                }
                Console.WriteLine();
            }


            //Nu ska vi skriva matrixen på 3x3

            int startRad;
            int startColumn;
            int maxMatrix = (n - 2) * (m - 2);
            int sum = 0;
            int[] maxNumbers = new int[maxMatrix];

            startRad = 0;
            startColumn = 0;

            
            for (int a = 0; a < 3; a++)
            {
                for (int b = 0; b < 3; a++)
                {
                    if (a < arrays.GetLength(0) & b < arrays.GetLength(1))
                    {
                        sum += arrays[startRad, startColumn];
                    }
                    startColumn++;
                }
            }
            
            

            

            Console.ReadLine();

        }
    }
}
