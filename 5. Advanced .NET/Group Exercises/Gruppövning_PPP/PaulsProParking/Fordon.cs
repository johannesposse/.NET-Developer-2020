using System;
using System.Collections.Generic;
using System.Text;

namespace PaulsProParking
{
    public class Fordon
    {
        string RegNr { get; }
        public enum FordonsTyp { Bil = 4, Mc = 2, Trike = 3, Cykel = 1};

        FordonsTyp fordonsTyp { get; }

        public Fordon()
        {
            //kostruktor för att skapa fordon
        }
    }
}
