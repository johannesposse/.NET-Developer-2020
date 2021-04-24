using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Felhantering
{
    public class MinMaxValue
    {
        private int max;
        private int min;
        private int value;

        public MinMaxValue(int min, int max)
        {
            this.max = max;
            this.min = min;
        }

        public int Max
        {
            get { return max;  }
            set { this.max = value; }
        }
        public int Min
        {
            get { return min; }
            set { this.min = value;  }
        }

        public int Value
        {
            get { return this.value; }
            set 
            {
                if (value < this.min)
                {
                    throw new System.ArgumentOutOfRangeException(value + " är ett för litet tal, välj mellan "  + this.min + "-" + this.max);
                }
                if (value > this.max)
                {
                    throw new System.ArgumentOutOfRangeException(value + " är ett för stort tal, välj mellan "  + this.min + "-" + this.max);
                }
                else
                {
                    this.value = value;
                }  
            }
        }
    }
}
