using System;
using System.Collections.Generic;
using System.Text;
using Log;
using API;

namespace PaulsProParking
{
    public class Kund
    {
        enum FaktureringsAlternativ { Daglig = 1, TioDagar = 10, TjugoDagar = 20, TrettioDagar = 30, EjFaktureras = 0 }
        public EventHandler<SkapaFaktura> skapafaktura;
        public EventHandler<Parkerad24h> parkerad24h;

        string Namn { get; }
        int TelefonNummer { get; set; }
        string Email { get; set; }
        FaktureringsAlternativ faktureringsAlternativ { get; set; }
        int KundID { get; }

        List<ParkeringsTillfälle> parkeringsTillfälle = new List<ParkeringsTillfälle>();

        public Kund(string namn, int telefonnummer, string email, int faktureringsalternativ, int kundID)
        {
            this.Namn = namn;
            this.TelefonNummer = telefonnummer;
            this.Email = email;
            this.faktureringsAlternativ = (FaktureringsAlternativ)faktureringsalternativ;
            this.KundID = kundID;

            this.parkerad24h += SmsAPI.Reader;
            this.skapafaktura += WebAPI.Reader;

            OnSkapaFatura();
            OnParkerad24h();
        }

        protected virtual void OnSkapaFatura()
        {
            //en whileloop som kollar varje varje dag min med hjälp av threads och sleep om faktureringsalternativ är uppfyllt och skickar en faktura
            //efter det fakturerats så töms listan 
            SkapaFaktura skapaFaktura = new SkapaFaktura();
            skapafaktura?.Invoke(this, skapaFaktura);
        }

        protected virtual void OnParkerad24h()
        {
            //en whileloop som kollar varje 30e min med hjälp av av threads och sleep om listan av parkeringstillfällens bool är true med en for loop
            Parkerad24h parkerad24H = new Parkerad24h();
            parkerad24h?.Invoke(this, parkerad24H);
        }

    }
}
