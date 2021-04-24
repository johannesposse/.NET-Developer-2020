using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamWriter one = new StreamWriter("1.txt");

            using (one)
            {
                one.WriteLine("Rad 1");
                one.WriteLine("Rad 2");
                one.WriteLine("Rad 3");
                one.WriteLine("Rad 4");
                one.WriteLine("Rad 5");
            }

            StreamReader rOne = new StreamReader("1.txt");
            StreamWriter two = new StreamWriter("2.txt");


            bool print = false;
            int i = 1;

            while (print == false)
            {
                string content = "";
                using (one)
                {   
                    content = rOne.ReadLine();
                }

                if (content == null)
                {
                    print = true;
                }
                else
                {
                    Console.WriteLine(i);
                    two.WriteLine("{0}: {1}", i, content);
                    i++;
                }           
            }

            two.Close();


            Console.WriteLine("Färdig");
            Console.ReadLine();

        }
    }
}
