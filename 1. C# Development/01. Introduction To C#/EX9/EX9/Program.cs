using System;

namespace EX9
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2, maxNumber, i;
            num1 = 2;
            num2 = -3;
            maxNumber = 5;
            i = 0;

            while (i < maxNumber)
            {
                Console.Write(num1 + " , " + num2 + " , ");
                num1 = num1 + 2;
                num2 = num2 - 2;
                i++;
            }
            Console.ReadLine();
        }
    }
}
