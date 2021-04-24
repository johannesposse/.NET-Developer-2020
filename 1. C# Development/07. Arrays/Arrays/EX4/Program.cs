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
            //Write a program that finds the maximal sequence of equal elements in an array.
            //Example: { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1} 🡪 { 2, 2, 2}.

            int[] array = new int[] { 2, 1, 1, 2, 3, 2, 2, 2, 2, 1 };
            int tempcount = 1;
            int count = 0;

            

            for (int i = 0; i < array.Length -1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    tempcount++;
                }
                else tempcount = 1;  
                if(tempcount > count)
                {
                    count = tempcount;
                }
            }

            Console.WriteLine("Maximalt upprepade nummer: " + count);
            Console.ReadLine();



        }
    }
}
