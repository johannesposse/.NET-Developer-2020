using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class PasswordRandomizer
    {
        private const string CapitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string SmallLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string Digits = "1234567890";
        private const string SpecialChars = @"~!@#$%^&*()_+=`{}[]\\|':;.,/?<>";
        private const string AllChars = CapitalLetters + SmallLetters + Digits + SpecialChars;
        private static Random rnd = new Random();

        public void PasswordBuilder(int num)
        {
            StringBuilder Password = new StringBuilder();

            for (int i = 0; i < 2; i++) //Upper
            {
                int random = rnd.Next(Password.Length+1);
                char cap = GenererateCapital();
                Password.Insert(random, cap);
            }

            for (int i = 0; i < 2; i++) //Lower
            {
                int random = rnd.Next(Password.Length + 1);
                char low = GenerateLower();
                Password.Insert(random, low);
            }

            for (int i = 0; i < 1; i++) //Digit
            {
                int random = rnd.Next(Password.Length + 1);
                char dig = GenerateNumber();
                Password.Insert(random, dig);
            }

            for (int i = 0; i < 1; i++) //Special
            {
                int random = rnd.Next(Password.Length + 1);
                char special = GenerateSpecial();
                Password.Insert(random, special);
            }

            for (int i = 0; i < (num - 6); i++) //All
            {
                int random = rnd.Next(Password.Length + 1);
                char all = GenerateAll();
                Password.Insert(random, all);
            }
            Console.WriteLine(Password);
        }

        private char GenererateCapital()
        {
            int num = rnd.Next(0, 25);
            char capital = CapitalLetters[num];
            return capital;
        }

        private char GenerateLower()
        {
            int num = rnd.Next(0, 25);
            char Lower = SmallLetters[num];
            return Lower;
        }

        private char GenerateNumber()
        {
            int num = rnd.Next(0, 9);
            char dig = Digits[num];
            return dig;
        }

        private char GenerateSpecial()
        {
            int num = rnd.Next(0, 30);
            char special = SpecialChars[num];
            return special;
        }

        private char GenerateAll()
        {
            int num = rnd.Next(0, 92);
            char all = AllChars[num];
            return all;
        }
    }
}
