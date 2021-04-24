using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    class LineStar : Truck
    {
        private string name;
        public LineStar()
        {
            name = "LineStar";
        }
        public string Name
        {
            get { return name; }
        }
        public override string RunOver(Car c)
        {
            return $"The {Name} ran over and crushed the {c}, killing everyone inside!";
        }
    }
}
