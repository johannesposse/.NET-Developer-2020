using System;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    class ParkingHouse
    {
        string Name { get; set; }
        ParkingSlot[] parkingSlots;

        public ParkingHouse(string name, int size)
        {
            this.Name = name;
            this.parkingSlots = new ParkingSlot[size];
        }


 
    }
}
