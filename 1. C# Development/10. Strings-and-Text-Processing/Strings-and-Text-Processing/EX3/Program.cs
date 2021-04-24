using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3
{
    class Program
    {
        static void Main(string[] args)
        {
            int count1 = 0;
            int count2 = 0;
            string str = "((a+b)/5-d)";
            Console.WriteLine(str);

            char[] s = str.ToCharArray();

            for (int i = 0; i < str.Length; i++)
            {
                if (s[i] == '(')
                {
                    count1++;
                }
                if (s[i] == ')')
                {
                    count2++;
                }
            }

            if (count1 != count2)
            {
                Console.WriteLine("Incorrect expression");
            }else Console.WriteLine("Correct Expression");


            Console.ReadLine();
        }
    }
}
