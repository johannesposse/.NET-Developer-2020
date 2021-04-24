using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamWriter fil1 = new StreamWriter("fil1.txt");
            StreamWriter fil2 = new StreamWriter("fil2.txt");
            
            //fil3.Close();

            using (fil1)
            {
                fil1.Write("fil1");
            }
            using (fil2)
            {
                fil2.Write("fil2");
            }

            StreamReader rFil1 = new StreamReader("fil1.txt");
            StreamReader rFil2 = new StreamReader("fil2.txt");

            string readFil1;
            string readFil2;

            using (rFil1)
            {
                readFil1 = rFil1.ReadToEnd();
            }

            using (rFil2)
            {
                readFil2 = rFil2.ReadToEnd();
            }

           

            StreamWriter fil3 = new StreamWriter("fil3.txt");
            using (fil3)
            {
                fil3.WriteLine(readFil1);
                fil3.WriteLine(readFil2);
            }

            StreamReader rFil3 = new StreamReader("fil3.txt");
            using (rFil3)
            {
                Console.WriteLine(rFil3.ReadToEnd());
            }

            Console.ReadLine();
            
            



        }
    }
}
