using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1
{
    abstract class Shape
    {
        protected double width { get;  set; }
        protected double height { get;  set; }

        protected Shape(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public abstract double CalculateSurface();
    }
}
