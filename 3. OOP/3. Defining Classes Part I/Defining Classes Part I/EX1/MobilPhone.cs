using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1
{
    public class MobilPhone
    {
        private string model;
        private string manufacturer;
        private int price;
        private string owner;

        public string Model
        {
            get { return this.model; }
        }
        public string Manufacturer
        {
            get { return this.manufacturer; }
        }

        public int Price
        {
            get { return this.price; }
        }
        public string Owner
        {
            get { return this.owner; }
        }

        public MobilPhone()
        {

        }
        public MobilPhone(string model, string manufacturer, int price, string owner)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
        }

        public MobilPhone(string model, string manufacturer)
        {
            this.model = model;
            this.manufacturer = manufacturer;
        }


    }
}
