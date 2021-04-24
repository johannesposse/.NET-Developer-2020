using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount acct = new BankAccount(10);
            Thread[] threads = new Thread[15];

            Thread.CurrentThread.Name = "main";

            for(int i = 0; i < 15; i++)
            {
                Thread t = new Thread(new ThreadStart(acct.IssueWithday));
                t.Name = i.ToString();
                threads[i] = t;
            }

            for(int i = 0; i < 15; i++)
            {
                Console.WriteLine("Thread {0} Alive : {1}", threads[i].Name, threads[i].IsAlive);
                threads[i].Start();
                Console.WriteLine("Thread {0} Alive : {1}", threads[i].Name, threads[i].IsAlive);
            }

            Console.WriteLine("Current Priority : {0}",Thread.CurrentThread.Priority);
            Console.WriteLine("Thread {0} Ending", Thread.CurrentThread.Name);


            Console.ReadLine();
        }

        
    }

    class BankAccount
    {
        private Object acctLock = new object();
        double Balance { set; get; }


        public BankAccount(double balance)
        {
            Balance = balance; 
        }

        public double Withdraw(double amt)
        {
            if((Balance - amt) < 0)
            {
                Console.WriteLine($"Sorry ${Balance} in Account");
                return Balance;
            }

            lock (acctLock)
            {
                if(Balance >= amt)
                {
                    Console.WriteLine("Removed {0} and {1} left in Account",amt, (Balance - amt));
                    Balance -= amt;
                }
                return Balance;
            }
        }

        public void IssueWithday()
        {
            Withdraw(1);
        }
    }
}
