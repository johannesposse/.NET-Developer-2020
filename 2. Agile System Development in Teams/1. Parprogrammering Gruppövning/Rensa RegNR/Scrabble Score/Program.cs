using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Scrabble_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            bool a = true;
            while (a == true)
            {
                Console.Write("Skriv in ditt ord: ");
                string word = Console.ReadLine();
                int points = ScrabblePoint(word);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0} fick {1} poäng", word, points);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ReadLine();
        }
        static int ScrabblePoint(string word)
        {
            int score = 0;
            int multiplier = 1;
            int wordMultiplier = 1;
            word = word.ToUpper();
            if (word[0] == '2')
                wordMultiplier = 2;
            if (word[0] == '3')
                wordMultiplier = 3;
            for (int i  = 0; i < word.Length; i++)
            {
                multiplier = 1;
                if (i < word.Length - 1)
                {
                    if (word[i + 1] == '2')
                        multiplier = 2;
                    if (word[i + 1] == '3')
                        multiplier = 3;
                }
                if (word[i] == 'A' || word[i] == 'E' || word[i] == 'I' || word[i] == 'O' || word[i] == 'U' || word[i] == 'L' || word[i] == 'N' || word[i] == 'R' || word[i] == 'S' || word[i] == 'T')
                    score += 1 * multiplier;
                if (word[i] == 'D' || word[i] == 'G')
                    score += 2 * multiplier;
                if (word[i] == 'B' || word[i] == 'C' || word[i] == 'M' || word[i] == 'P')
                    score += 3 * multiplier;
                if (word[i] == 'F' || word[i] == 'H' || word[i] == 'V' || word[i] == 'W' || word[i] == 'Y')
                    score += 4 * multiplier;
                if (word[i] == 'K')
                    score += 5 * multiplier;
                if (word[i] == 'J' || word[i] == 'X')
                    score += 8 * multiplier;
                if (word[i] == 'Q' || word[i] == 'Z')
                    score += 10 * multiplier;
            }
            score = score * wordMultiplier;
            return score;
        }
    }

   
}
