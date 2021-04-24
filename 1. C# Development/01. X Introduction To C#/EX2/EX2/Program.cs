using System;

namespace EX2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello C#");
            Console.Write("Skriv ditt namn: ");
            String name = Console.ReadLine();
            Console.WriteLine("Hej " + name);
            Console.ReadLine();
        }
    }
}
