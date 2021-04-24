using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RensaRegNr
{
    class Program
    {
        static void Main(string[] args)
        {
            bool infinite = true;
            while (infinite == true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Skriv in regnr: ");
                Console.ForegroundColor = ConsoleColor.White;
                string regNr = Console.ReadLine();
                string returnRegNr;
                bool result = RensaRegNr(regNr, out returnRegNr);
                if (result == true)
                    Console.WriteLine("Det tvättade regnr är {0}", returnRegNr);
                if (result == false & returnRegNr.Length < 3)
                    Console.WriteLine("Regnr är kortare än 3 tecken");
                if (result == false & returnRegNr.Length > 10)
                    Console.WriteLine("Regnr är längre än 10 tecken");
            }
            Console.ReadLine();
        }
        static bool RensaRegNr(string regNrln, out string regNrOut)
        {
             string rensad = Regex.Replace(regNrln, "[^a-zA-Z0-9]+", "", RegexOptions.Compiled);
            rensad = rensad.ToUpper();
            regNrOut = rensad;
            if (rensad.Length < 3 || rensad.Length > 10)
            {
                return false;
            }
            else
                return true;
        }
    }
}
