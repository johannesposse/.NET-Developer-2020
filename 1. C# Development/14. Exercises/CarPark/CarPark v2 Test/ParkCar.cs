using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CarPark_v2_Test
{
    class ParkVehicle
    {
        private string regNr;
        private string typeOfVehicle;
        private int parkingslot;
        private string parkTime;

        public ParkVehicle()
        {

        }

        public string RegNr
        {
            get { return this.regNr; }
            set 
            {
                if (value.Length > 10)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    this.regNr = value;
                }
            }
        }

        public string TypeOfVehicle
        {
            get { return this.typeOfVehicle; }
            set
            { 
                if (value != "car" & value != "mc")
                {
                    throw new Exception("fel typ av fordon");
                }
                else
                {
                    this.typeOfVehicle = value;
                }
            }
        }

        public int ParkingSlot
        {
            get { return this.parkingslot; }
            set 
            { 
                if (value < 1 || value > 100)
                {
                    //throw new ArgumentOutOfRangeException();
                }
                else
                {
                    this.parkingslot = value;
                }
                
            }
        }

        public string ParkTime
        {
            get { return this.parkTime; }
            set { this.parkTime = value; }
        }

    }
}
