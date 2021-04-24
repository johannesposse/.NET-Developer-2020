using System;
using System.Dynamic;

namespace EX1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that reads 3 integer numbers from the console and prints their sum.

            int nr1, nr2, nr3, sum;
            nr1 = int.Parse(Console.ReadLine());
            nr2 = int.Parse(Console.ReadLine());
            nr3 = int.Parse(Console.ReadLine());
            sum = nr1 + nr2 + nr3;
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
