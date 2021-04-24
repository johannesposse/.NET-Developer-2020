using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX5
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter b = new StreamWriter("1.txt");
           
            b.WriteLine("4");
            b.Close();
            
            
            StreamReader a = new StreamReader("1.txt");

            int matrix;

            matrix = int.Parse(a.ReadLine());
            a.Close();

            b = new StreamWriter("1.txt");

            b.Write("sss");
            b.Close();

            Random rnd = new Random();


            

            

            for (int i = 0; i < matrix*2; i++)
            {
                
            }
            

            Console.ReadLine();


        }
    }
}
