using System;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    class Fordon
    {
        internal string RegNr { get; set; }
        internal int Size { get; set; }

        internal string VehicleType { get; set; }

        internal DateTime StartDate { get; set; }
        internal DateTime EndDate { get; set; }

        internal decimal ParkingFee { get; set; }
        internal bool InvoiceOption { get; set; }

        public Fordon(string regNr, string vehicleType)
        {
            this.RegNr = regNr;
            this.VehicleType = vehicleType;
            this.StartDate = DateTime.Now;
            Parked24h();
        }

        internal EventHandler<Events.Parked24h> Parked24hEvent;

        public async void Parked24h()
        {
            bool hours = false;

            while(hours == false)
            {
                if(this.StartDate > DateTime.Now)
                {

                }
            }
        }

    }
}
