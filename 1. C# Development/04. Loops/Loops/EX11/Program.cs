using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX11
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that prints all possible cards from a standard deck of 52 cards (without jokers). The cards should be printed with their English names. 
            //Use nested for loops and switch-case.

            string[] color = new string[] { "Ruter", "Hjärter", "Klöver", "Spader" };
            string[] typAvKort = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Knäckt", "Dam", "Kung", "Ess" };

            int maxTotal = 52;
            int kortPerFarg = 14;

            for (int i = 0; i < color.Length; i++)
            {
                for (int j = 0; j < typAvKort.Length; j++)
                {
                    Console.WriteLine(color[i] + " " + typAvKort[j]);
                }
            }

            Console.ReadLine();
        }
    }
}
