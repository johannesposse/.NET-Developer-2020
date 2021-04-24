using System;

namespace EX4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that reads two positive integer numbers and prints how many numbers p
            //exist between them such that the reminder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.

            uint a, b, p;
            a = 54;
            b = 121;
            p = 0;
            
            for (uint i = a; i <= b; i++)
            {
                if(i % 5 == 0)
                {
                    p++;
                }
            }
            Console.WriteLine(p);
        }
    }
}
