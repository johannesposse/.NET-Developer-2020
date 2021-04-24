using System;

namespace EX9
{
    class Program
    {
        static void Main(string[] args)
        {

            //Write a program to print the first 100 members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

            /*
            int fibSeuq = 1;
            int fibPlaceHolder = 0;
            int counter = 0;

            while (counter < 100)
            {
                Console.WriteLine(fibSeuq);
                fibPlaceHolder = fibSeuq - fibPlaceHolder;
                fibSeuq = fibPlaceHolder + fibSeuq;
                counter++;
            }
            */



            decimal f = 0;
            decimal g = 1;
            for (int i = 1; i <=100; i++)
            {

                Console.WriteLine(g);
                f = g - f;
                g = f + g;
    

            }
            Console.ReadLine();
}
}
}
