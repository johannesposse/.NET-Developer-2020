using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3
{
    class Kittens : Cats, ISound
    {
        
       public Kittens (int age, string name, bool isFemale, bool wild) : base(age, name, isFemale, wild)
        {
            this.sound = "Litet Mjao";
        }

        public string sound { get; set; }
        public override bool isFemale
        {
            get
            { return true;} 
        }

        public override string ToString()
        {
            return $"Kitten\nAge: {this.age}\nName: {this.name}\nIs Female: {this.isFemale}\nIs Wild: {this.wild}\nSound: {sound}\n";

        }
    }
}
