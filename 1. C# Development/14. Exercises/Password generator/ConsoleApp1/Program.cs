using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool a = false;
            int num = 0;
            while (a == false)
            {
                try
                {
                    Console.Write("Skriv hur många tecken, 8-16: ");
                    num = int.Parse(Console.ReadLine());

                    if (num > 7 & num < 17)
                    {
                        a = true;
                    }
                    else
                    {
                        Console.WriteLine("För litet eller för stort");
                    }
                }
                catch
                {
                    Console.WriteLine("Något blev fel...");
                }
                
            }
                
            PasswordRandomizer myRandomizer = new PasswordRandomizer();
            myRandomizer.PasswordBuilder(num);
            Console.ReadLine();
        }
    }
}
