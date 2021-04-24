using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1
{
    class Program
    {
        

        static void Main(string[] args)
        {

            //SimpleDelegate p = new SimpleDelegate(TestMethod);
            //p("test");



            var list = new List<int>() { 1, 2, 3, 4 };
            var evenNumbers = list.FindAll(x => (x % 2) == 0);

            foreach(var e in evenNumbers)
            {
                Console.WriteLine(e);
            }

            var pets = new []
            {
                new { Name="Share", Age=2},
                new { Name="Rex", Age=4 },
                new { Name="Strela", Age=1 },
                new { Name="Bora", Age=3 }

            };

            var sortedPets = pets.OrderBy(pet => pet.Age);

            foreach (var p in sortedPets)
            {
                Console.WriteLine("{0} -> {1}",
                p.Name, p.Age);

            }

            int a = 0;












            var test = "Jag heter Johannes";
            Console.WriteLine(test.WordCount());
            int i = 2;
            Console.WriteLine(i.MACKA(1));

            var myCar = new { Color = "red", Brand = "BMW", Speed = 180 };
            Console.WriteLine(myCar.Color);

            var arr = new[] { new { X = 2, Y = 5 }, new { X = 100, Y = 2 } };

            Console.WriteLine(arr[1].X);


        }
    }
    public delegate void SimpleDelegate(string param);
    public class DelegatesExample
    {
        public static void TestMethod(string param)
        {
            Console.WriteLine("I was calles");
            Console.WriteLine("I got " + param);
        }
    }

    public static class Extensions
    {
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static int MACKA(this int i, int b)
        {
            return i + b;
        }
    }
}
