using System;

namespace EX12
{
    class Program
    {
        static void Main(string[] args)
        {
            int age;
            age = 0;
            
            while (age == 0)
            {
                try
                {
                    Console.Write("Skriv hur gammal du är: ");
                    age = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Nu blev nåt fel");
                }
            }
                
            if (age > 0)
            {
                int newAge = age + 10;
                Console.WriteLine("Om 10 år är du " + newAge);
                Console.ReadLine();
            }
            


        }
    }
}
