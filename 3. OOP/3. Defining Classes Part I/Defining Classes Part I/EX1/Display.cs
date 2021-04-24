using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1
{
    class Display
    {
        private double displaySize;
        private int displayColour;

        public double DisplaySize
        {
            get { return this.displaySize; }
        }
        public int DisplayColour
        {
            get { return this.displayColour; }
        }

        public Display(double displaySize, int displayColour)
        {
            this.displaySize = displaySize;
            this.displayColour = displayColour;
        }
    }
}
