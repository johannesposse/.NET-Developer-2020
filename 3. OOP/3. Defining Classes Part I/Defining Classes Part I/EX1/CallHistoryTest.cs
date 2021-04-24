using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1
{
    class CallHistoryTest
    {
        public void Test()
        {
            GSM phone = new GSM("Banana Phone", "Fruit", 20,"The Banana Man", "Banana", 2,1,0,5,1);
            phone.AddCall(DateTime.Now, "555-5555",180);
            phone.AddCall(DateTime.Now, "0340-112", 3.7);
            phone.AddCall(DateTime.Now, "555-5555", 190);
            phone.AddCall(DateTime.Parse("2020,06,07 12:20:03"), "0340-112", 15.5);
            phone.AddCall(DateTime.Parse("2019,05,21 03:15:27"), "0340-112", 120.1);
            phone.PrintCall();
            phone.CallPrice();
            phone.DeleteCall("delete longest call");
            phone.CallPrice();
            phone.ClearCallHistory();
            phone.PrintCall();
        }
    }
}
