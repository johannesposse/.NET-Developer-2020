using System;

namespace DesignPatterns
{
    class Program
    {
        public static void Main(string[] args)
        {
            AbstractAutoFactory europe = new AutoFactoryEurope();
            Traffic traffic = new Traffic(europe);
            Console.WriteLine(traffic.RunTraffic());

            AbstractAutoFactory america = new AutoFactoryAmerica();
            traffic = new Traffic(america);
            Console.WriteLine(traffic.RunTraffic());
        }
    }
}
