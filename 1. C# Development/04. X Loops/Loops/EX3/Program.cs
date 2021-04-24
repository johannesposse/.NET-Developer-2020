using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.
            // 1,2,3

            Console.Write("Skriv in hur många tal du vill jämföra: ");
            int n = int.Parse(Console.ReadLine());
            int[] arrays = new int[n];
            int min = 0;
            int max = 0;

            for (int c = 0; c <n; c++)
            {
                Console.Write("Skriv in tal {0}: ", c + 1);
                arrays[c] = int.Parse(Console.ReadLine());
                
            }
  
            max = arrays.Max();
            min = arrays.Min();

            Console.WriteLine("Minsta numret är {0}, Största numret är {1}", min, max);
            Console.ReadLine();

        }
    }
}
