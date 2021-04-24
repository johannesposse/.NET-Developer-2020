using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning
{
    class Kort
    {
        enum Färg
        {
            Hjärter, Spader, Ruter, Klöver
        }
        enum Valör
        {
            Två, Tre, Fyra, Fem, Sex, Sju, Åtta, Nio, Tio, Knäckt, Dam, Kung, Ess
        }

        public Enum valör { get; set; }
        public Enum färg { get; set; }
        

        public Kort(int valör, int färg)
        {
            this.valör = (Valör)valör;
            this.färg = (Färg)färg;
        }

        public Kort(){}

        public override string ToString()
        {
            return $"{färg}\t {valör}\n";
        }



    }
}
