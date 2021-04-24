using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1
{
    struct Point3D
    {
        public Point3D(int x,int z, int y)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        private int x { get; set; }
        private int z { get; set; }
        private int y { get; set; }
        static readonly int start = 0;

        public static int Start
        {
            get { return start; }
        }
        public override string ToString()
        {
            return $"X: {x}\nY: {y}\nZ: {z}";
        }
    }
}
