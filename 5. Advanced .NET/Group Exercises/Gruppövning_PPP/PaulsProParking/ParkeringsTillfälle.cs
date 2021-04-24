using System;
using System.Collections.Generic;
using System.Text;

namespace PaulsProParking
{
    public class ParkeringsTillfälle
    {
        bool ÄrFordonParked24h { get; set; }
        DateTime AnkomstTid { get; } = DateTime.Now;
        DateTime UtcheckningsTid { get; set; }
        decimal Kostnad { get; set; }  //ska finnas logic som räknar ut priset baserat på parkeringstid och fordonstyp
        Fordon fordon { get; set; }
        int ParkeringsRutaID { get; set; }

        public ParkeringsTillfälle()
        {
            //konstruktor för att skapa instans med in parametrar

            FordonParkeradMerÄn24h();
        }

        static void FordonParkeradMerÄn24h()
        {
            //metod med en whileloop som kollar var 30e min om fordonet har vart parkerat mer än 24h med hjälp av async och sleep och ändrar
            //boolen till true 
        }


    }
}
