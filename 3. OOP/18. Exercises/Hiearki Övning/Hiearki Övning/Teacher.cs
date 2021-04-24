using System;
using System.Collections.Generic;
using System.Text;

namespace Hiearki_Övning
{
    public class Teacher : Person
    {
        protected string subject { get; private set; }

        public Teacher (string EMail, string name, string subject) : base(EMail, name)
        {
            this.subject = subject;
        }
    }
}
