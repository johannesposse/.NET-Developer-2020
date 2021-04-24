using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_Klocka
{
    class TickEventArgs : EventArgs
    {
        public DateTime Time { get; set; }
        public bool Cancel { get; set; }

        public TickEventArgs(DateTime time, bool cancel = false)
        {
            this.Time = time;
            this.Cancel = cancel;
        }

        public override string ToString()
        {
            return this.Time.ToString("hh:mm:ss");
        }
    }
}
