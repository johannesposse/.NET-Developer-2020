using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5. Print the obtained array on the console.

            int[] numbers = new int[20];

            for (int i = 0; i <20; i++)
            {
                numbers[i] = (i * 5);
            }

            foreach(int number in numbers)
            {
                Console.WriteLine(number);
            }
            Console.ReadLine();

        }
    }
}
