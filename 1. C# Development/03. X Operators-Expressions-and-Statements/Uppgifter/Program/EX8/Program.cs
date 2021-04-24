using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write an expression that calculates trapezoid's area by given sides a and b and height h.
            //The formula of the area of a trapezoid is 1/2*height*(base1+base2)
            int aSide, bSide, height;
            double traArea;
            aSide = 3;
            bSide = 10;
            height = 7;
            traArea = 0.5 * height * (aSide + bSide);
            Console.WriteLine(traArea);
            Console.Read();
        }
    }
}
