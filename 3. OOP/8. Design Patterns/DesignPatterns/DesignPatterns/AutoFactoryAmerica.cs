using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    class AutoFactoryAmerica : AbstractAutoFactory
    {
        public override Car CreateCar()
        {
            return new FordFocus();
        }
        public override Truck CreateTruck()
        {
            return new LineStar();
        }
    }
}
