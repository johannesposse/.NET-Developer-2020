using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LinqÖvningar
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MyRegion
            //Employee[] developers = new Employee[]
            //{
            //    new Employee { ID  = 1, Name = "Johannes Posse"},
            //    new Employee {ID = 2, Name = "Fuck Boi"},
            //    new Employee {ID = 3, Name = "Jonas"}
            //};

            //IEnumerable<Employee> sales = new List<Employee>()
            //{
            //    new Employee { ID = 3, Name = "Jack Harding"}
            //};

            //IEnumerable<Employee> test = developers.Where(x => x.Name.StartsWith("J") );

            //foreach (var d in developers.Where(x => x.Name.StartsWith("J") && x.Name.Length > 8))
            //{
            //    Console.WriteLine(d.Name);
            //}

            //var filteredEmployees =
            //    from dev in developers
            //    where dev.Name.StartsWith("J") && dev.Name.Length > 8 
            //    orderby dev.Name
            //    select dev;

            //foreach(var f in filteredEmployees)
            //{
            //    Console.WriteLine(f.Name);
            //}

            //Func<int, int, int> testFuck = (x, y) => x + y;

            //Console.WriteLine(testFuck(5,2)); 
            #endregion

            double d = double.Parse("1,8");

            Console.WriteLine(d);

            Console.WriteLine();

            var cars = ProcesFile("E:\\Google Drive\\Programmering\\SUT20\\Kurs 5 - Avancerad .NET\\LINQ\\LinqÖvningar\\LinqÖvningar\\CSV\\fuel.csv");

            var qw = cars.OrderByDescending(x => x.Combined).ThenBy(x => x.Name);

            int i = 1;

            Console.WriteLine($"{"Name",-30} {"Fuel Efficienty",25}\n========================================================\n");

            foreach (var q in qw.Take(20)) 
            {
                Console.WriteLine($"{i++ +":",-4}{q.Name,-30} => {q.Combined,10}");
            }
        }

        private static List<Car> ProcesFile(string path)
        {
            return File.ReadAllLines(path).Skip(1).Where(x => x.Length > 1).Select(Car.CSV).ToList();
        }

    }
}
