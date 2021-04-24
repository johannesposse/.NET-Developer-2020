using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EX3
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Skriv in sökväg för att skapa ett dokument: ");
            string sokVag = Console.ReadLine();
            sokVag += @"\";
            Console.WriteLine("Skriv in vad dokumentet ska heta: ");
            Console.Write(sokVag);
            string sokVagName = sokVag + Console.ReadLine();
            sokVagName += ".txt";
            Console.WriteLine("Vad vill du skriva i dokumentet?: ");
            string appendText = Console.ReadLine();

            Console.WriteLine(sokVagName);


            File.AppendAllText(sokVagName, appendText, Encoding.UTF8);

            Console.WriteLine(File.ReadAllText(sokVagName));

            /*
            string filePath = @"C:\Users\johan\Desktop\temp.txt";
            
            //Lägg till dokument om det inte finns
            if (!File.Exists(filePath))
            {
                string createtext = "ÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖÖH" + Environment.NewLine;
                File.WriteAllText(filePath, createtext, Encoding.UTF8);
            }

            
            //lägg till text i dokument
            string addText = "är det bästa som finns" + Environment.NewLine;
            File.AppendAllText(filePath, addText, Encoding.UTF8);
            

            //läs dokument
            string readText = File.ReadAllText(filePath);
            Console.WriteLine(readText);
            */

            Console.ReadLine();
        }
    }
}
