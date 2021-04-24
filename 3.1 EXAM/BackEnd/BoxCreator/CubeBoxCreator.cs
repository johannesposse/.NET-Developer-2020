using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    [Serializable] //för att kunna spara med Binary Serialization
    class CubeBoxCreator : BoxCreator //class för att skapa CubeBox som ärver ifrån BoxCreator
    {
        internal decimal side;
        int iD;
        uint weight;
        bool isFragile;
        int insurance;

        internal CubeBoxCreator(int iD,  uint weight, bool isFragile, int insurance, decimal side)
        {
            this.iD = iD;
            this.weight = weight;
            this.isFragile = isFragile;
            this.side = side;
            this.insurance = insurance;
        }

        internal override I3DStorageObject CreateBox()
        {
            return new CubeBox(this.iD, this.weight,this.isFragile,this.insurance, this.side); // Skriver över interfacet som ärvs av BoxCreator, och skickar tillbaka en ny CubeBox
        }
    }
}
