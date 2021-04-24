using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX4
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamWriter one = new StreamWriter("1.txt");
            StreamWriter two = new StreamWriter("2.txt");

            Random rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                one.WriteLine(rnd.Next(1, 4));
                two.WriteLine(rnd.Next(1, 4));
            }

            one.Close();
            two.Close();

            StreamReader rOne = new StreamReader("1.txt");
            StreamReader rTwo = new StreamReader("2.txt");

            string cOne = "";
            bool a = false;
            int j = 0;

            while (a == false)
            {     
                j++;
                cOne = rOne.ReadLine();
                string cTwo = rTwo.ReadLine();

                if (cOne == null)
                {
                    a = true;
                }
                else
                {
                   
                    if (cOne == cTwo)
                    {
                        Console.WriteLine("Rad {0} är samma: {1} {2}", j, cOne, cTwo);
                        
                    }
                    else
                    {
                        Console.WriteLine("Rad {0} är inte samma: {1} {2}", j, cOne, cTwo);
                        
                    } 
                }
            }

            rOne.Close();
            rTwo.Close();

            Console.Read();
        }
    }
}
