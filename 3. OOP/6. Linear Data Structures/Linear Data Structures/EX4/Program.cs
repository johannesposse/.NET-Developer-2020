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
            List<int> a = new List<int> { -2,3,-6,5,5,-2,2,2,-5,5,5,5,1};
            List<int> result = new List<int>();
            result =  Longest(a);
            foreach(var b in result)
                Console.WriteLine(b);
            Console.WriteLine();
            List<int> remove = new List<int>();
            remove = Remove(a);
            foreach (var b in remove)
                Console.WriteLine(b);
            Console.ReadLine();
        }
        static List<int> Longest (List<int> a)
        {
            List<int> result = new List<int>();
            int tempCount = 1;
            int count = 1;
            int num = 0;
            for(int i=0; i < a.Count-1; i++)
            {
                if (a[i] == a[i + 1])
                {
                    tempCount++;
                    if (tempCount > count)
                        count = tempCount;
                        num = a[i];
                }
                else
                    tempCount = 1;
            }
            for (int i = 0; i < count; i++)
                result.Add(num);
            return result;
        }
        static List<int> Remove(List<int> a)
        {
            //List<int> result = new List<int>();
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] < 0)
                {
                    a.RemoveAt(i);
                }
            }
            return a;
        }
    }
}
