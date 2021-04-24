using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings_and_Text_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "sample";
            char[] charRev = str.ToCharArray();
            Array.Reverse(charRev);

            //new string(charRev);
            charRev.ToString();

            Console.WriteLine(charRev);
            Console.ReadLine();

        }
    }
}
