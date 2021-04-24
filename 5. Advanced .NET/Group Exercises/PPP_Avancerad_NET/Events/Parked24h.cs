using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    class Parked24h : EventArgs
    {
        string RegNr { get; set; }
        string Message { get; set; }

        public Parked24h(string regNr, string message)
        {
            this.RegNr = regNr;
            this.Message = message;
        }

    }
}
