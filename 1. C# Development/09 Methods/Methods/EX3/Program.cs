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
            Console.WriteLine(lastDigit(65408.ToString()));
            Console.ReadLine();
        }

        static string lastDigit (string num)
        {
            string result = " ";

            if (num[num.Length - 1] == '0')
            {
                result = "zero";
            }
            if (num[num.Length - 1] == '1')
            {
                result = "one";
            }
            if (num[num.Length - 1] == '2')
            {
                result = "two";
            }
            if (num[num.Length - 1] == '3')
            {
                result = "three";
            }
            if (num[num.Length - 1] == '4')
            {
                result = "four";
            }
            if (num[num.Length - 1] == '5')
            {
                result = "five";
            }
            if (num[num.Length - 1] == '6')
            {
                result = "six";
            }
            if (num[num.Length - 1] == '7')
            {
                result = "seven";
            }
            if (num[num.Length - 1] == '8')
            {
                result = "eight";
            }
            if (num[num.Length - 1] == '9')
            {
                result = "nine";
            }
            return result;
        }
    }
}
