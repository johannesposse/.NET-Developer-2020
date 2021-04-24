using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning
{
    class Program
    {
        static void Main(string[] args)
        {
            //Läs in ett värde från consolen som talar om hur stor er array skall vara.
            //Fyll vare position i arrayen med en random int(det finns en sådan funktion i.net så googla)
            //skriv sedan ut värdet i varje position  och summan av värdena med hjälp av en for each loop

            Console.Write("Skriv hur många värden arrayen ska ha: ");
            uint number = uint.Parse(Console.ReadLine());
            int[] numberArrays = new int[number];
            Random randome = new Random();
            int c = 1;

            for (int i = 0; i < numberArrays.Length; i++)
            {
                numberArrays[i] = randome.Next(-2000, 2000);
                Console.WriteLine("Tal nr: " + c + " " + numberArrays[i]);
                c++;
            }

            Console.ReadLine();
        }
    }
}
