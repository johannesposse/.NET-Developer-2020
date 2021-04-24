using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EX1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter writer = new StreamWriter("test.txt");


            
            using (writer)
            {
                for (int i = 0; i <20; i++)
                {
                    writer.WriteLine(i+1);
                }
                
            }


            StreamReader read = new StreamReader("test.txt");

            //content = read.ReadLine();
            string content = "";
            using (read)
            {
                while (content != null)
                {
                    content = read.ReadLine();
                    Console.WriteLine(content);
                    content = read.ReadLine();
                }
            }

            Console.ReadLine();
        }
    }
}
