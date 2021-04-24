using System;

namespace EX8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that reads an integer number n from the console and prints all the numbers in the interval [1..n],
            //each on a single line.

            Console.WriteLine("Enter a number greater than 1");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1 ; i <= (n-1); i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(n);
            Console.ReadLine();
        }
    }
}
