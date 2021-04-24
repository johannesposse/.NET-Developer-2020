using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that finds the maximal increasing sequence in an array. Example: 
            //{ 3, 2, 3, 4, 2, 2, 4} 🡪 { 2, 3, 4}.

            int[] arrays = new int[] { 3, 2, 3, 4, 2, 2, 4 };
            int[] maxs = new int[arrays.Length];

            int tal1, tal2, result;
            result = 0;

            int pos = 0;


            for (int i = 0; i < arrays.Length -1; i++)
            {
                tal1 = arrays[i];
                tal2 = arrays[i + 1];
                if (tal1 > tal2)
                {
                    result = 0;
                }
                else
                {
                    result = tal1;
                    maxs[pos] = result;
                    pos++;
                }
               
                   
               
                
            }

            foreach (int max in maxs)
            {
                Console.WriteLine(max);
            }
            Console.ReadLine();
        }
    }
}
