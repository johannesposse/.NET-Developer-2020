using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    [Serializable] //för att kunna spara med Binary Serialization

    abstract class BoxCreator //abstract klass som gör det möjligt att skapa olika typer av lådor
    {
        internal abstract I3DStorageObject CreateBox();
    }

}
