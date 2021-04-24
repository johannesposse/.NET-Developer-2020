using System;
using System.Collections.Generic;
using System.Text;

namespace PaulsProParking
{
    class Anställd
    {
        string Namn { get; set; }
        int TelefonNummer { get; set; }
        string Email { get; set; }
        int AnställdID { get; set; }
        Enum ArbetsRoll { get; set; }


        public Anställd(string namn, int telefonnummer, string email, int faktureringsalternativ, int anställdID)
        {
            this.Namn = namn;
            this.TelefonNummer = telefonnummer;
            this.Email = email;
            //Enum
            this.AnställdID = anställdID;
        }
    }
}
