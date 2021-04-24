using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning
{
    class Program
    {
        static void Main(string[] args)
        {
            //string a = "hej";
            Kortlek a = new Kortlek();
            Kortlek b = new Kortlek();
            List<Kort> bordet = new List<Kort>();
            a.Initialize();
            Kort c = a.RemoveFirstCard();
            a.Empty();
            a.BlandaNy();
            Console.WriteLine( a);

            
            a.AddCard(c, 5);
            Console.WriteLine(a);


            Console.ReadLine();
            
        }
    }
}
