using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    [Serializable] //för att kunna spara med Binary Serialization
    class SphereBoxCreator : BoxCreator //class för att skapa SphereBox som ärver ifrån BoxCreator
    {
        internal decimal radius;
        int iD;
        uint weight;
        bool isFragile;
        int insurance;

        internal SphereBoxCreator(int iD, uint weight, bool isFragile, int insurance, decimal radius)
        {
            this.iD = iD;
            this.weight = weight;
            this.isFragile = isFragile;
            this.radius = radius;
            this.insurance = insurance;
        }

        internal override I3DStorageObject CreateBox() // Skriver över interfacet som ärvs av BoxCreator, och skickar tillbaka en ny SphereBox
        {
            return new SphereBox(this.iD, this.weight, this.isFragile, this.insurance, this.radius);
        }
    }
}
