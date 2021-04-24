using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    class Traffic
    {
        private Car car;
        private Truck truck;
        public Traffic(AbstractAutoFactory factory)
        {
            car = factory.CreateCar();
            truck = factory.CreateTruck();
        }
        public string RunTraffic()
        {
            return truck.RunOver(car);
        }
    }
}
