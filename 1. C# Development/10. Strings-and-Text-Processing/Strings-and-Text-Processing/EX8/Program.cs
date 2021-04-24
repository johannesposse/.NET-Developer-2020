using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX8
{
    class Program
    {
        static void Main(string[] args)
        {

            string srt = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

            string[] split = srt.Split('.');
            StringBuilder s = new StringBuilder();


            for (int i = 0; i < split.Length; i++)
            {

                if (split[i].Contains(" in "))
                {
                    string temp = split[i];
                    string clean = temp.TrimStart();
                    int l = s.Length;
                    s.Insert(l, clean + ".\n");

                }
            }

            Console.WriteLine("\n\n" + s);

            Console.ReadLine();
        }
    }
}
