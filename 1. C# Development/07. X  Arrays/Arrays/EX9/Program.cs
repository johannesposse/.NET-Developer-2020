using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX9
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that finds the most frequent number in an array. Example:
            //{ 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} 🡪 4(5 times)

            int[] arrays = new int[] { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
            int max = 0;
            int tempmax = 0;
            int mostFrequent = 0;

            for (int i = 0; i < arrays.Length -1; i++)
            {
                for (int j = 0; j < arrays.Length -1; j++)
                {
                    if (arrays[i] == arrays[j])
                    {
                        tempmax++;
                    }
                    if (tempmax > max)
                    {
                        max = tempmax;
                        mostFrequent = arrays[i];
                    }
                }
                tempmax = 0;
            }

            foreach (int array in arrays)
            {
                Console.Write(array);
            }
            Console.WriteLine();
            Console.WriteLine("Det nummer som finns med flest gånger är {0}, det finns med {1} gånger", mostFrequent, max);
            Console.ReadLine();
        }
    }
}
