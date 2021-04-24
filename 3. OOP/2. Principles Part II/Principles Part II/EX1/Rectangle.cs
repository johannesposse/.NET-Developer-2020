using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1
{
    class Rectangle : Shape
    {

        public Rectangle(double width, double height) : base(width, height) { }


        public override double CalculateSurface()
        {
            return height * width;
        }
        public override string ToString()
        {
            return $"Rectangle\nWithd: {this.width}\nHeight: {this.height}\nArea: {CalculateSurface()}\n";
        }
    }

}
