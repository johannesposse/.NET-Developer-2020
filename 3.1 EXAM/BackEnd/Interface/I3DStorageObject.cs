using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    
    public interface I3DStorageObject //Interface som gör det möjligt att skapa nya lådor, ta emot olika lådor och spara olika lådor
    {
        int ID { get;}
        string Description { get; }
        uint Weight { get; }
        decimal Volume { get; }
        decimal Area { get; }
        bool IsFragile { get; }
        decimal MaxDimension { get; }
        int InsuranceValue { get; set; }
    }
}
