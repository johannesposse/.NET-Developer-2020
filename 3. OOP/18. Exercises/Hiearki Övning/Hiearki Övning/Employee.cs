using System;
using System.Collections.Generic;
using System.Text;

namespace Hiearki_Övning
{
    public class Employee : Person
    {
        protected int employeeID { get;private set; }
        public string jobTitle { get; set; }

        public Employee(string EMail, string name, int employeeID, string jobTitle) : base(EMail, name)
        {
            this.employeeID = employeeID;
            this.jobTitle = jobTitle;
        }
    }
}
