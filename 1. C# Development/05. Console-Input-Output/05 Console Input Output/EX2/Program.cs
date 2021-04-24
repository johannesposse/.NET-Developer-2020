using System;

namespace EX2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that reads the radius r of a circle and prints its perimeter and area.

            double r, p, a;
            Console.Write("Skriv radien: ");
            r = int.Parse(Console.ReadLine());
            p = (r + r) * Math.PI;
            a = (r * r) * Math.PI;

            Console.WriteLine("Cirkeln har en radie på: {0}, en omkretts på: {1} och en area på: {2}", r, p, a);
        }
    }
}
