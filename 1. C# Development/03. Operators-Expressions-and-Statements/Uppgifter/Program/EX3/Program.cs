using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write an expression that calculates rectangle’s area by given width and height.
            int height, width, area;
            height = 40;
            width = 80;
            area = height * width;
            Console.WriteLine("Rektangelns area är: " + area);
            Console.ReadLine();
        }
    }
}
