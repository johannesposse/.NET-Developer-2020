using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that reads two arrays from the console and compares them element by element.

            int[] first = new int[] {1,2,3,4,5};
            int[] second = new int[] { 5, 4, 3, 2, 1};

            for (int i = 0; i < 5; i++)
            {
                if (first[i] == second[i])
                {
                    Console.WriteLine("Tal nr {0}, ({1},{2}) är samma i båda arrayerna", i, first[i], second[i]);
                }
                else
                {
                    Console.WriteLine("Tal nr {0}, ({1},{2}) är inte samma i båda arrayerna", i, first[i], second[i]);
                }
            }
            Console.ReadLine();


        }
    }
}
