using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3
{
    class Dog : Animals, ISound
    {
        protected bool goodBoy { get; private set; }

        public Dog (int age, string name, bool isFemale) : base(age, name, isFemale)
        {
            this.goodBoy = goodBoy;
            this.sound = "woof";
        }

        public override bool isFemale { get; set; }
        public string sound { get; set; }
      

        public override string ToString()
        {
            return $"Dog\nName: {this.name}\nAge: {this.age}\nIs Female: {this.isFemale}\nGood Boy: {this.goodBoy}\nSound: {sound}\n";
        }

       
    }
}
