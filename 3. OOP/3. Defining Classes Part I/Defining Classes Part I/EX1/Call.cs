using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1
{
    class Call
    {
        private DateTime date = new DateTime();
        private string phoneNumber;
        private double duration;
        
        public DateTime Date
        {
            get { return this.date; }
        }
        public string PhoneNumber
        {
            get { return this.phoneNumber; }
        }
        public double Duration
        {
            get { return this.duration; }
        }

        public Call(DateTime date, string phoneNumber, double duration)
        {
            this.date = date;
            this.phoneNumber = phoneNumber;
            this.duration = duration;
        }

        public override string ToString()
        {
            return $"Call\nTime:\t\t {this.date}\nNumber:\t\t {this.phoneNumber}\nDuration:\t {this.duration} min\n";
        }
    }
}
