using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    class Vehicle 
    {
        private readonly string regNr;
        private int vehicleType;
        private DateTime parkTime;
        private int currentParkTime;
        private int parkingFee;
        private int parkingSlot;


        public int ParkingSlot //property för parkeringsplats
        {
            get => this.parkingSlot;
            set => this.parkingSlot = value;
        }
        public string RegNr //propterty för registreringsnummer
        {
            get => this.regNr;
        }

        public int VehicleType //property för fordonstyp
        {
            get => this.vehicleType;
        }

        public DateTime ParkTime //property för när fordonet parkerades
        {
            get => this.parkTime;
        }

        public int CurrentParkTime //property för hur länge det har vart parkerat
        {
            get => this.currentParkTime;
        }

        public int ParkingFee //propterty för avgigten
        {
            get => this.parkingFee;
        }

        public Vehicle(int parkingSlot, string regNr, int vehicleType, DateTime parkTime, int currentParkTime, int parkingFee) //construktor för att kunna skapa nya fordon
        {
            this.ParkingSlot = parkingSlot;
            this.regNr = regNr;
            this.vehicleType = vehicleType;
            this.parkTime = parkTime;
            this.currentParkTime = currentParkTime;
            this.parkingFee = parkingFee;
        }
    }
}
