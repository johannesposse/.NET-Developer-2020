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
            //Write a program that compares two char arrays lexicographically (letter by letter).

            char[] char1 = new char[5] { 'a', 'b', 'c', 'd','e'};
            char[] char2 = new char[5] { 'a', 'a', 'c', 'd', 'e' };
            bool equal = true;

            if (char1.Length > char2.Length) Console.WriteLine("Den andra arrayen är först");
            else if (char1.Length < char2.Length) Console.WriteLine("Den första arrayen är först");

            for (int i = 0; i < 5; i++)
            {
                if (char1[i] > char2[i])
                {
                    Console.WriteLine("Försa arrayen är först");
                    equal = false;
                    break;
                }
                if (char1[i] < char2[i])
                {
                    Console.WriteLine("Den andra arrayen är först");
                    equal = false;
                    break;
                }
            }
            if (equal) Console.WriteLine("Dom är lika");
            Console.ReadLine();
        }
    }
}
