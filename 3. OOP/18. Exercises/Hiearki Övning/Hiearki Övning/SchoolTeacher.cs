using System;
using System.Collections.Generic;
using System.Text;

namespace Hiearki_Övning
{
    public class SchoolTeacher : Teacher
    {
        protected string school { get; private set; }

        public SchoolTeacher(string EMail, string name, string subject, string school) : base(EMail, name, subject)
        {
            this.school = school;
        }

        public override string ToString()
        {
            return "SchoolTeacher: " + this.EMail + " " + this.name + " " + this.subject + " " + this.school;
        }
    }
}
