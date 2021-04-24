using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3
{
    class TomCats : Cats, ISound
    {
        public TomCats(int age, string name, bool isFemale, bool wild) : base(age, name, isFemale, wild)
        {
            this.sound = "Stort Mjau";
        }

        public string sound { get; set; }
        public override bool isFemale
        {
            get
            { return false; }
        }

        public override string ToString()
        {
            return $"Tomcat\nAge: {this.age}\nName: {this.name}\nIs Female: {this.isFemale}\nIs Wild: {this.wild}\nSound: {sound}\n";

        }
    }
}
