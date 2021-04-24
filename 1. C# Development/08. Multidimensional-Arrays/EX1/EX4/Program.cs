using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX4
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Skriv in hur många rader arrayen ska ha: ");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Skriv in hur många columner arrayen ska ha: ");
            int column = int.Parse(Console.ReadLine());

            int[,] arrays = new int[row,column];
            int size = row * column;
            int counter = 0;

            int[] arraysSorted = new int[size];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    arraysSorted[counter] = arrays[i, j];
                }
            }
        }
    }
}
