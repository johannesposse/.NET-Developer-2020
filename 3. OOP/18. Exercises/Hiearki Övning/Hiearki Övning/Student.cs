using System;
using System.Collections.Generic;
using System.Text;

namespace Hiearki_Övning
{
    public class Student : Person
    {
        protected int studentId { get; private set; }

        public Student(string EMail, string name, int studentId) : base(EMail, name)
        {
            this.studentId = studentId;
        }
    }
}
