using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {

            Member person1 = new Member(102,27,"Johannes","Posse");
            Member person2 = new Member(103, 28, "Mia", "Svensson");

            /*
            try
            {
                Console.Write("Skriv in medlemsnummer: ");
                person1.MemberNo = int.Parse(Console.ReadLine());
                Console.Write("Skriv in ålder: ");
                person1.Age = int.Parse(Console.ReadLine());
                Console.Write("Skriv in förnamn: ");
                person1.FirstName = Console.ReadLine();
                Console.Write("Skriv in efternamn: ");
                person1.LastName = Console.ReadLine();
            }
            catch (SystemException fe)
            {
                Console.WriteLine(fe.Message);
            }
            */

            using (StreamWriter person = new StreamWriter("members.csv"))
            {
                person.WriteLine(person1.Result);
                person.Flush();
            }

            string a;
            using (StreamReader rPerson = new StreamReader("members.csv"))
            {
                a = rPerson.ReadToEnd();
                //Console.WriteLine("\n" + rPerson.ReadToEnd());
            }

            string[] b = a.Split(',');

            foreach (string c in b)
            {
                Console.Write(c+ " ");
            }
           

            Console.ReadLine();

        }
    }
}
