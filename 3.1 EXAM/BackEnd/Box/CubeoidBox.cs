using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    [Serializable] //för att kunna spara med Binary Serialization
    class CubeoidBox : I3DStorageObject
    {

        internal CubeoidBox(int iD, uint weight, bool isFragile, int insurance, decimal xSide, decimal ySide, decimal zside)
        {
            ID = iD;
            Weight = weight;
            Xside = xSide;
            Yside = ySide;
            Zside = zside;
            IsFragile = isFragile;
            Description = "CubeoidBox";
            decimal[] max = { Xside, Yside, Zside };
            MaxDimension = max.Max();
            try //om talet blir för stort för en decimal
            {
                Area = 2 * ((Zside * Xside) + (Zside * Yside) + (Xside * Yside));
            }
            catch
            {
                throw new ArgumentOutOfRangeException("The radius is too big...");
            }
            Area = Area / 10000; //för att få fram m2
            if (Area < 0.01M) // om arean är mindre än 0.01m2 så sätts den till 0.01m2
            {
                Area = 0.01M;
            }
            Area = Math.Round(Area, 2); //rundar av till 2 decimaler
            try //om talet blir för stort för en decimal
            {
            Volume = (Xside * Yside) * Zside;
            }
            catch
            {
                throw new ArgumentOutOfRangeException("The radius is too big...");
            }
            Volume = Volume / 1000000; //för att få fram m3
            if (Volume < 0.01M) // om volume är mindre än 0.01m3 så sätts den till 0.01m3
            {
                Volume = 0.01M;
            }
            Volume = Math.Round(Volume, 2); //rundar av till 2 decimaler
            InsuranceValue = insurance;
        }


        public decimal Xside { get; private set; }
        public decimal Yside { get; private set; }
        public decimal Zside { get; private set; }

        public int ID { get; private set; }

        public string Description { get; private set; }

        public uint Weight { get; private set; }

        public decimal Volume { get; private set; }

        public decimal Area { get; private set; }

        public bool IsFragile { get; private set; }

        public decimal MaxDimension { get; private set; }

        public int InsuranceValue { get; set; }

        public override string ToString() //skickar ut lådans egenskaper som en string
        {
            return $"--[ID: {ID}]  \t[Description: {Description}]  \t[MaxDimension: {MaxDimension} cm]  \t[Weight: {Weight} kg]  \t[Area: {Area.ToString("F")} m2]  \t[Volume: {Volume.ToString("F")} m3]  \t[Fragile: {IsFragile}]  \t[Insurance: {InsuranceValue.ToString("C")}]";
        }
    }
}
