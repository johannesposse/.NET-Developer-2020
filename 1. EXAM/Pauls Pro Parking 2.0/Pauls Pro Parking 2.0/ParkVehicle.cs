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
        private string regNrTemp;
        readonly string regNr;
        private string typeOfVehicle;
        private string parkTime;
        private string regNrTemp2;
        readonly string regNr2;
        private string typeOfVehicle2;
        private string parkTime2;

        public ParkVehicle(string _regNr, string _regNr2)
        {
            regNrTemp = _regNr;
            regNrTemp2 = _regNr2;
            regNr = regNrTemp;
            regNr2 = regNrTemp2;
        }
        public ParkVehicle()
        {

        }
        public string RegNr
        {
            get { return this.regNrTemp; }
        }
        public string RegNr2
        {
            get { return this.regNrTemp2; }
        }
        public string TypeOfVehicle
        {
            get { return this.typeOfVehicle; }
            set
            {
                if (value != "car" & value != "mc") //kollar så att det är rätt sorts fordon
                {
                    throw new Exception("Wrong vehicle type");
                }
                else
                {
                    this.typeOfVehicle = value;
                }
            }
        }
        public string TypeOfVehicle2
        {
            get { return this.typeOfVehicle2; }//kollar så att det är rätt sorts fordon
            set
            {
                if (value != "car" & value != "mc")
                {
                    throw new Exception("Wrong vehicle type");
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
