using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    [Serializable] //för att kunna spara med Binary Serialization
    class CubeoidBoxCreator : BoxCreator //class för att skapa CubeoidBox som ärver ifrån BoxCreator
    {
        internal decimal Xside;
        internal decimal Yside;
        internal decimal Zside;
        int iD;
        uint weight;
        bool isFragile;
        int insurance;

        internal CubeoidBoxCreator(int iD, uint weight, bool isFragile, int insurance, decimal Xside, decimal Yside, decimal Zside)
        {
            this.iD = iD;
            this.weight = weight;
            this.isFragile = isFragile;
            this.insurance = insurance;
            this.Xside = Xside;
            this.Yside = Yside;
            this.Zside = Zside;
        }

        internal override I3DStorageObject CreateBox() // Skriver över interfacet som ärvs av BoxCreator, och skickar tillbaka en ny CubeoidBox
        {
            return new CubeoidBox(this.iD, this.weight, this.isFragile, this.insurance, this.Xside, this.Yside, this.Zside);
        }
    }
}
