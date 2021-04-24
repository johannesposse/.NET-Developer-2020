using System;
using System.Collections.Generic;
using System.Text;

namespace Hiearki_Övning
{
    public class Person
    {
        protected string EMail { get; private set; }
        protected string name { get; private set; }

        public Person(string EMail, string name)
        {
            this.EMail = EMail;
            this.name = name;
        }
    }
}
