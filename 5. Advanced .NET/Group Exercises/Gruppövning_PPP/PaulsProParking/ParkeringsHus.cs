using System;
using System.Collections.Generic;
using System.Text;

namespace PaulsProParking
{
    class ParkeringsHus
    {
        List<ParkeringsRuta[]> parkeringsRutor = new List<ParkeringsRuta[]>();
        
        int size;

        

        public ParkeringsHus(int size)
        {
            ParkeringsRuta[] parkeringsRuta = new ParkeringsRuta[size];
            parkeringsRutor.Add(parkeringsRuta);
        }

        public void ExtraParkeringLäggTill(int size)
        {
            ParkeringsRuta[] parkeringsRuta = new ParkeringsRuta[size];
            parkeringsRutor.Add(parkeringsRuta);
        }

        public void ExtraParkeringTaBort()
        {
            parkeringsRutor.RemoveAt(parkeringsRutor.Count - 1);
        }


    }
}
