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
            Shape[] shapes = new Shape[15];
            Random a = new Random();
            int z = 0;
            for (int i = 0; i < 5; i++)
            {
                shapes[z] = new Triangle(a.Next(1, 100), a.Next(1, 100));
                shapes[z+1] = new Rectangle(a.Next(1, 100), a.Next(1, 100));
                shapes[z + 2] = new Circle(a.Next(1, 100), a.Next(1, 100));
                z = z + 3;
            }
            for (int i = 0; i < shapes.Length; i++)
            {
                Console.WriteLine(shapes[i]);
            }
            Console.ReadLine();
        }
    }
}
