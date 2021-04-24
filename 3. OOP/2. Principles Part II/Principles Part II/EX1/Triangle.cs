using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1
{
    class Triangle : Shape
    {
        public Triangle (double width, double height) : base(width, height )
        {
            
        }

        public  override double CalculateSurface()
        {
            return (height * width) / 2;
        }
        public override string ToString()
        {
            return $"Triangle\nWithd: {this.width}\nHeight: {this.height}\nArea: {CalculateSurface()}\n";
        }
    }
}
