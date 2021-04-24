using System;

namespace EX6
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName, lastName;
            Console.Write("Skriv ditt förnamn: ");
            firstName = Console.ReadLine();
            Console.Write("Skriv ditt efternamn: ");
            lastName = Console.ReadLine();
            Console.WriteLine("Du heter " + firstName + " " + lastName);
            Console.ReadLine();
        }
    }
}
