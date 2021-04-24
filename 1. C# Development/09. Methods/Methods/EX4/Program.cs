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
            int[] nums = { 1, 2, 3, 4, 4,4,5,5,5,6};
            int times = 6;
            Console.WriteLine(Counter(nums, times));
            Console.ReadLine();
        }

        static int Counter (int[] num, int times)
        {
            int counter = 0;

            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] == times)
                {
                    counter++;
                }
            }

            return counter;
        }
    }


}
