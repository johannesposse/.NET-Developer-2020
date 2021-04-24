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
            //Write a program that prints all the numbers from 1 to N.

            Console.WriteLine("Vänligen skriv in ett nummer >1: ");
            uint maxNr = uint.Parse(Console.ReadLine());
            int startNr = 1;

            for (int i = 1; i <= maxNr; i++)
            {
                Console.WriteLine(startNr);
                startNr++;
            }
            Console.ReadLine();
        }
    }
}
