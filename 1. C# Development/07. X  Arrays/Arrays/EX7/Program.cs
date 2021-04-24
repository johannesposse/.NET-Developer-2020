using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. 
            //Use the "selection sort" algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.

            int[] arrays = new int[] { 3, 2, 1, 10, 5,9,-100,75,80,-1523,25,-5862,5,3,6,5,10,1,1,2};
            int placeholder = 0;
            int placeholder2 = 0;

            for (int i = 0; i < arrays.Length; i++)
            {
                for (int j = 0; j < arrays.Length - 1; j++)
                {
                    if (arrays[j] > arrays[j + 1])
                    {
                        placeholder = arrays[j];
                        placeholder2 = arrays[j + 1];
                        arrays[j] = placeholder2;
                        arrays[j + 1] = placeholder;
                    }
                }
            }
            

            foreach (int array in arrays)
            {
                Console.WriteLine(array);
            }
            Console.ReadLine();
        }
    }
}
