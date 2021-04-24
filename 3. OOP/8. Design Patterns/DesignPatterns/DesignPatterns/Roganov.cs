using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    class Roganov : Truck
    {
        private string name;
        public Roganov()
        {
            name = "Roganov";
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
