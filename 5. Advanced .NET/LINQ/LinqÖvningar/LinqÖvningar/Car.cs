using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqÖvningar
{
    public class Car
    {
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Displacement { get; set; }
        public int Cylinder { get; set; }
        public int City { get; set; }
        public int HighWay { get; set; }
        public int Combined { get; set; }

        internal static Car CSV(string line)
        {
            var input = line.Split(",");

            input[3] = input[3].Replace('.', ',');
            return new Car
            {
                Year = int.Parse(input[0]),
                Manufacturer = input[1],
                Name = input[2],
                Displacement = double.Parse(input[3]),
                Cylinder = int.Parse(input[4]),
                City = int.Parse(input[5]),
                HighWay = int.Parse(input[6]),
                Combined = int.Parse(input[7])

            };
        }
    }
}
