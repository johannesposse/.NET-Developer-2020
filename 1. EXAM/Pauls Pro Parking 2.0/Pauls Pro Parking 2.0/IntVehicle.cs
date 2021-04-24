using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CarPark_v2_Test
{
    class IntVehicle
    {
        private string regNr;
        private string typeOfVehicle;
        private string parkTime;
        private string regNr2;
        private string typeOfVehicle2;
        private string parkTime2;

        public IntVehicle()
        {

        }
        public string RegNr
        {
            get { return this.regNr; }
            set
            {
                if (value.Length > 10)//kollar så att regnr inte är mer än 10 tecken
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    this.regNr = value;
                }
            }
        }
        public string RegNr2
        {
            get { return this.regNr2; }
            set
            {
                if (value.Length > 10) //kollar så att regnr inte är mer än 10 tecken
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    this.regNr2 = value;
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
                    throw new Exception("Wrong vehicle type");//kollar så att det är rätt sorts fordon
                }
                else
                {
                    this.typeOfVehicle = value;
                }
            }
        }
        public string TypeOfVehicle2
        {
            get { return this.typeOfVehicle2; }
            set
            {
                if (value != "car" & value != "mc")
                {
                    throw new Exception("Wrong vehicle type");//kollar så att det är rätt sorts fordon
                }
                else
                {
                    this.typeOfVehicle2 = value;
                }
            }
        }
        public string ParkTime
        {
            get { return this.parkTime; }
            set { this.parkTime = value; }
        }
        public string ParkTime2
        {
            get { return this.parkTime2; }
            set { this.parkTime2 = value; }
        }

    }
}
