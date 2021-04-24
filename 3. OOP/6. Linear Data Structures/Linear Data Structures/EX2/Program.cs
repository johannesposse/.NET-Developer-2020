using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> a = new Stack<int>();
            Console.WriteLine("How many? ");
            int many = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            for (int i = 0; i < many; i++)
            {
                a.Push(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine("\n");
            while (true)
            {
                if (a.Count() > 0)
                    Console.WriteLine(a.Pop());
                else
                    break;
            }

            //for (int i = (int)a.Count(); i == a.Count(); i--)
            //{
            //    Console.WriteLine(a.Pop());
            //}
            Console.ReadLine();
        }
    }
}
