using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX4
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            string str = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

            char[] s = str.ToCharArray();

            Console.WriteLine(s);

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (s[i] == 'i' & s[i + 1] == 'n')
                {
                    count++;
                }
                if (s[i] == 'I' & s[i + 1] == 'n')
                {
                    count++;
                }

            }

            int cunt = 0;
            string[] words = str.Split(' ', '.');

            Console.WriteLine(words[1]);

            for (int i = 0; i < words.Length; i++)
            {
                int index = words[i].IndexOf("in");
                //Console.WriteLine(index);
                int index2 = words[i].IndexOf("In");
                Console.WriteLine("Index2 " + index2);

                if (index >= 0)
                {
                    cunt++;
                }
                if (index2 >= 0)
                {
                    cunt++;
                }
            }

            Console.WriteLine("Första " + count);
            Console.WriteLine("Andra " + cunt);

            Console.ReadLine();
        }
    }
}
