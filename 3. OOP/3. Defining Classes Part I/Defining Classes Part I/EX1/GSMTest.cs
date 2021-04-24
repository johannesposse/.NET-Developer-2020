using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1
{
    class GSMTest
    {
        public void Test()
        {
            GSM[] test = new GSM [4];

            test[0] = new GSM("iphone", "Apple", 10000, "Johannes Posse", "Basic", 20, 10, 1, 6, 20);
            test[1] = new GSM("One Plus", "China", 6000, "Sven Ingvarsson", "Electric", 10, 5, 2,7.5,15);
            test[2] = new GSM("Xiamo", "Tchaina");
            test[3] = GSM.IPhone4S;

            for (int i = 0; i < test.Length; i++)
            {
                Console.WriteLine(test[i]);
            }
        }



    }
}
