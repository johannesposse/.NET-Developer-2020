using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    class AutoFactoryEurope : AbstractAutoFactory
    {
        public override Car CreateCar()
        {
            return new VolvoV70();
        }
        public override Truck CreateTruck()
        {
            return new Roganov();
        }
    }
}
