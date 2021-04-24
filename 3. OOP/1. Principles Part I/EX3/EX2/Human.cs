using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2
{
    abstract class Human
    {
        public string firstName { get; private set; }
        protected string lastName { get; private set; }

        public Human (string firstName, string lastName)
        {
            this.lastName = lastName;
            this.firstName = firstName;
        }
    }
}
