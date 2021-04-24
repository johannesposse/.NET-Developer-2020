using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    abstract class AbstractAutoFactory
    {
        public abstract Car CreateCar();
        public abstract Truck CreateTruck();
    }
}
