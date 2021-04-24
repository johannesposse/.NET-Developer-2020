using System;

namespace EX7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum. 
            decimal n = 1;
            int i = 1;
            Decimal b;

            while (i <= 100)
            {
                Console.WriteLine("Rad " + i + " " + n);
                n++;
                i++;
            }
            Console.ReadLine();
        }
    }
}
