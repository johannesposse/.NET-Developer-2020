using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3
{
    abstract class Cats : Animals
    {
        protected bool wild { get; private set; }

        public Cats(int age, string name, bool isFemale, bool wild) : base (age, name, isFemale)
        {
            this.wild = wild;
        }

        public override bool isFemale { get; set; }
        

    }
}
