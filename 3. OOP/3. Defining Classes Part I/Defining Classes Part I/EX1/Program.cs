using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EX1
{
    class Program
    {
        static void Main(string[] args)
        {
            string christmas = @"
  __  __                          _____ _          _     _                       
 |  \/  |                        / ____| |        (_)   | |                      
 | \  / | __ _ _ __ _ __ _   _  | |    | |__  _ __ _ ___| |_ _ __ ___   __ _ ___ 
 | |\/| |/ _` | '__| '__| | | | | |    | '_ \| '__| / __| __| '_ ` _ \ / _` / __|
 | |  | | (_| | |  | |  | |_| | | |____| | | | |  | \__ \ |_| | | | | | (_| \__ \
 |_|  |_|\__,_|_|  |_|   \__, |  \_____|_| |_|_|  |_|___/\__|_| |_| |_|\__,_|___/
                          __/ |                                                  
                         |___/                                                   
";
            Random r = new Random();
            
            for (int i = 0; i <christmas.Length; i++)
            {
                Console.ForegroundColor = (ConsoleColor)r.Next(11,13);
                Console.Write(christmas[i]);
                if(christmas[i] !=' ')
                {
                    Thread.Sleep(1);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            GSMTest test = new GSMTest();
            test.Test();
            CallHistoryTest testa = new CallHistoryTest();
            testa.Test();
            Console.ReadLine();
        }
    }
}
