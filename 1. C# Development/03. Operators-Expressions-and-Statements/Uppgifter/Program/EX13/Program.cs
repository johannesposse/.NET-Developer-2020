using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX13
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.
            //Förstår inte riktigt hur denna funkar
            //Försökte göra en egen men funkade inte som jag hade tänkt.

            Console.Write("Enter number: ");
            int v = Convert.ToInt32(Console.ReadLine());
            int mask = 1 << 3;
            int bitAt3 = (v & mask) != 0 ? 1 : 0;
            mask = 1 << 4;
            int bitAt4 = (v & mask) != 0 ? 1 : 0;
            mask = 1 << 5;
            int bitAt5 = (v & mask) != 0 ? 1 : 0;
            mask = 1 << 24;
            int bitAt24 = (v & mask) != 0 ? 1 : 0;
            mask = 1 << 25;
            int bitAt25 = (v & mask) != 0 ? 1 : 0;
            mask = 1 << 26;
            int bitAt26 = (v & mask) != 0 ? 1 : 0;

            v = (bitAt3 == 0) ? v = v & (~(1 << 24)) : v = v | (1 << 24);
            v = (bitAt4 == 0) ? v = v & (~(1 << 25)) : v = v | (1 << 25);
            v = (bitAt5 == 0) ? v = v & (~(1 << 26)) : v = v | (1 << 26);
            v = (bitAt24 == 0) ? v = v & (~(1 << 3)) : v = v | (1 << 3);
            v = (bitAt25 == 0) ? v = v & (~(1 << 4)) : v = v | (1 << 4);
            v = (bitAt26 == 0) ? v = v & (~(1 << 5)) : v = v | (1 << 5);

            Console.WriteLine(v);
            Console.ReadLine();
        }       
    }
}
