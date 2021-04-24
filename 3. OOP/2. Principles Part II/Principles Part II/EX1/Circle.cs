using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1
{
    class Circle : Shape
    {
        public Circle(double width, double height) : base(width, height) 
        {
            if (width > height)
            {
                this.height = width;
            }
            if (width < height)
            {
                this.height = width;
            }
        }

        public override double CalculateSurface()
        {
            return width * Math.PI;
        }

        public override string ToString()
        {
            return $"Circle\nWithd: {this.width}\nHeight: {this.height}\nArea: {CalculateSurface()}\n";
        }
    }
}
