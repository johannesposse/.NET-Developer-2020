using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).
            uint N, K, FK, FN;
            decimal result;
            FK = 1;
            FN = 1;


            Console.Write("Skriv in värdet på K: ");
            K = uint.Parse(Console.ReadLine());
            Console.Write("Skriv in värdet på N, det måste vara mindre än K, men större än ett: ");
            N = uint.Parse(Console.ReadLine());

            while (N > K | N < 1)
            {
                Console.WriteLine("Värdet på N var större än K eller mindre än 1, vänligen välj nya värden");
                Console.Write("Skriv in värdet på K: ");
                K = uint.Parse(Console.ReadLine());
                Console.Write("Skriv in värdet på N, det måste vara mindre än K: ");
                N = uint.Parse(Console.ReadLine());

            }

            for (uint i = 1; i <= K; i++)
            {
                FK = FK * i;
            }
            for (uint j = 1; j <= N; j++)
            {
                FN = FN * j;
            }

            result = FN * FK / (K - N);

            Console.WriteLine("FN: {0}, FK: {1}", FK, FN);
            Console.WriteLine("N!*K! / (K-N)!: {0}", result);
            Console.ReadLine();
        }
    }
}
