using System;

namespace EX5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.
            int a, b, result;
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            result = Math.Max(a, b);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
