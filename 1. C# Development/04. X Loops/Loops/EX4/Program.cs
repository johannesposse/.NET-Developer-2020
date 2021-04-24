using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EX4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that calculates N!/K! for given N and K (1<K<N).
            int N, K, FK, NK;
            decimal result;
            FK = 1;
            NK = 1;
            

            Console.Write("Skriv in värdet på K: ");
            K = int.Parse(Console.ReadLine());
            Console.Write("Skriv in värdet på N, det måste vara mindre än K, men större än ett: ");
            N = int.Parse(Console.ReadLine());
           
            while (N > K | N < 1)
            {
                Console.WriteLine("Värdet på N var större än K eller mindre än 1, vänligen välj nya värden");
                Console.Write("Skriv in värdet på K: ");
                K = int.Parse(Console.ReadLine());
                Console.Write("Skriv in värdet på N, det måste vara mindre än K: ");
                N = int.Parse(Console.ReadLine());
                
            }

            for (int i = 1; i <= K; i++)
            {
                FK = FK * i;
            }
            for (int j = 1; j <= N; j++)
            {
                NK = NK * j;
            }

            result = FK / NK;

            Console.WriteLine("K är {0}, N är {1}. F!/K! är {2}", FK, NK, result);

            Console.ReadLine();
        }
    }
}
