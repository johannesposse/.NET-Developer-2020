using System;
using System.Collections.Generic;
using System.Text;

namespace PaulsProParking
{
    class ParkeringsRuta
    {
        int Size { get; set; } //hämtar värdet från fordonstypen



        int MaxSize { get; set; } = 4;   //ska finnas logic för att Size inte ska kunna vara större än MaxSize



        int ParkeringsRutaID { get; set; }

        List<Fordon> fordon = new List<Fordon>();

    }
}
