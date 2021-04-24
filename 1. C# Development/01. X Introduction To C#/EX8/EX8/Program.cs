using System;

namespace EX8
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1, num2, result;
            num1 = 12345;
            num2 = 2;
            result = Math.Pow(num1, num2);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
