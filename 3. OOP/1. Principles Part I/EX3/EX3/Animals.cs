using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3
{
      abstract class Animals 
    {
        protected int age { get; private set; }
        protected string name { get; private set; }
        public abstract bool isFemale { get; set; }

        public int Age 
        {
            get { return this.age; }
        }

        public Animals (int age, string name, bool isFemale)
        {
            this.age = age;
            this.name = name;
            this.isFemale = isFemale;
        }
    }

}
