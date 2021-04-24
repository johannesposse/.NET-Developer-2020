using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    [Serializable] //för att kunna spara med Binary Serialization
    class BlobBoxCreator : BoxCreator //class för att skapa BlobBox som ärver ifrån BoxCreator
    {
        internal decimal side;
        int iD;
        uint weight;
        int insurance;

        internal BlobBoxCreator(int iD, uint weight, int insurance, decimal side)
        {
            this.iD = iD;
            this.weight = weight;
            this.side = side;
            this.insurance = insurance;
        }

        internal override I3DStorageObject CreateBox() // Skriver över interfacet som ärvs av BoxCreator, och skickar tillbaka en ny BlobBox
        {
            return new BlobBox(this.iD, this.weight, this.insurance, this.side);
        }
    }
}
