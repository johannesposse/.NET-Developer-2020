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
            Point3D b = new Point3D(1, 2, 3);
            Console.WriteLine(b.ToString());
            
            int i = Point3D.Start;
            Console.WriteLine(i);

            Console.Read();
        }
    }
}
