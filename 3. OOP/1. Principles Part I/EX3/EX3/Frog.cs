using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3
{
    class Frog : Animals, ISound
    {
        protected int jumpDistance { get; set; }

        public Frog (int age, string name, bool isFemale, int jumpDistance) : base (age, name , isFemale)
        {
            this.jumpDistance = jumpDistance;
            this.sound = "quark";
        }

        public override bool isFemale { get; set; }
        public string sound { get; set; }

        public override string ToString()
        {
            return $"Frog\nName: {this.name}\nAge: {this.age}\nIs Female: {this.isFemale}\nJump: {this.jumpDistance}\nSound: {sound}\n";
        }
    }
}
