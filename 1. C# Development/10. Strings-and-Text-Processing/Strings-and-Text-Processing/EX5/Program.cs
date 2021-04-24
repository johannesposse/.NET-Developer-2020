using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX5
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 0;
            int slut = 0;
            char upper = ' ';
            string str = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
            StringBuilder strB = new StringBuilder(str);
            
            Console.WriteLine(strB);


            for (int i = 0; i < strB.Length-1; i++)
            {
                if (strB[i] == '<' & strB[i+1] == 'u')
                {
                    start = i + 7;
                    slut = start +100;
                }
                if (strB[i] == '<' & strB[i+1] == '/')
                {
                    slut = i;
                }

                if (start != 0)
                {
                    if (i > start & i < slut)
                    {
                        upper = strB[i];
                        upper = Char.ToUpper(upper);
                        strB[i] = upper;
                    }
                }
            }

            strB.Replace("<upcase>", "");
            strB.Replace("</upcase>", "");

            Console.WriteLine(strB);

            Console.ReadLine();
        }
    }
}
