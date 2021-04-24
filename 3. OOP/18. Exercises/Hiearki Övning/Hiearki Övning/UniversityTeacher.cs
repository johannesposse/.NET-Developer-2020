using System;
using System.Collections.Generic;
using System.Text;

namespace Hiearki_Övning
{
    public class UniversityTeacher : Teacher
    {
        protected string university { get;private set; }

        public UniversityTeacher(string EMail, string name, string subject, string university) : base(EMail, name, subject)
        {
            this.university = university;
        }

        public override string ToString()
        {
            return "UniversityTeacher: " + this.EMail + " " + this.name + " " + this.subject + " " + this.university;
        }
    }
}
