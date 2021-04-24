using System;
using System.Collections.Generic;
using System.Text;

namespace Hiearki_Övning
{
   public  class SeniorEmployee : Employee
    {
        protected int yearsExperience { get; private set; }

        public SeniorEmployee(string EMail, string name, int employeeID, string jobTitle, int yearsExperience) : base(EMail, name, employeeID, jobTitle)
        {
            this.yearsExperience = yearsExperience;
        }

        public override string ToString()
        {
            return "Senior Employee: " + this.EMail + ", " + this.name + ", " + this.employeeID + ", " + this.jobTitle + ", " + this.yearsExperience;
        }
    }
}
