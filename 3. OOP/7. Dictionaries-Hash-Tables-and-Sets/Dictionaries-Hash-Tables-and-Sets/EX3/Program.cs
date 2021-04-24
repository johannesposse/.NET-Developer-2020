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
            string text = "This is the TEXT. Text, text, text – THIS TEXT! Is this the text?";
            var word = new Dictionary<string, int>();

            string[] temp = text.Split(' ', '.', '–', '!', '?', ',');

            foreach (var t in temp)
            {
                string tt = t.ToLower();
                int count;
                if (!string.IsNullOrWhiteSpace(tt))
                {
                    if (!word.TryGetValue(tt, out count))
                        count = 0;
                    word[tt] = count + 1;
                }
            }

            foreach (var w in word)
                Console.WriteLine(w.Key + " >> " + w.Value);

            Console.WriteLine(word["text"].GetHashCode());
            Console.ReadLine();
        }
    }
}
