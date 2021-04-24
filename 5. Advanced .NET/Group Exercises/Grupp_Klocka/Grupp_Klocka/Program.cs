using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_Klocka
{
    class Program
    {
        static void Main(string[] args)
        {
            Klocka klocka = new Klocka();
            Visare visare = new Visare();
            FilLogger filLogger = new FilLogger();

            klocka.clock += visare.KlockLyssnare;
            klocka.clock += filLogger.KlockSkrivaTillFil;
            klocka.TheClock();

            Console.ReadLine();
        }
    }
}
