using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX10
{
    class Program
    {
        static void Main(string[] args)
        {

            string str = "Hi !";
            foreach(char s in str)
            {
                Console.Write("U{0:x4}/",(int) s);
            }

    

            Console.ReadLine();
        }
    }
}
