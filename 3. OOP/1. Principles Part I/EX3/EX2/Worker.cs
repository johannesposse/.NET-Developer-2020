using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2
{
    class Worker : Human
    {
        protected double weekSalary { get; private set; }
        protected double workHoursPerDay { get; private set; }

        public Worker (string firstName, string lastName, int weekSalary, int workHoursPerDay) : base(firstName, lastName)
        {
            this.weekSalary = weekSalary;
            this.workHoursPerDay = workHoursPerDay;
        }

         public double MoneyPerHour ()
        {
            return weekSalary / workHoursPerDay;
        }

        public override string ToString()
        {
            return $"Name:\t {this.firstName} {this.lastName}\nMPH:\t {MoneyPerHour()}\n";
        }
    }
}
