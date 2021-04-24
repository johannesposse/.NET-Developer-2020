using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2
{
    class Program
    {
        static List<Bank> accounts = new List<Bank>();
        static List<Company> companys = new List<Company>();
        static List<Induvidual> induviduals = new List<Induvidual>();
        static void Main(string[] args)
        {
            Menu();

            //Induvidual a = new Induvidual("Johannes Posse", true, true, true);
            //a.DepositAccount(1000,0);
            //a.DepositAccount(0, 500);
            //a.LoanAccount(0);
            //a.MortgageAccount(50);

            //Company b = new Company("Best Company", true, true, true);
            //b.DepositAccount(500000, 0);
            //b.LoanAccount(0);
            //b.MortgageAccount(0);

            Console.ReadLine();
        }

        static void Menu()
        {
            Console.Clear();
            string menu =
                "\n\n\n1. Add Private Costumer\n" +
                "2. Add Company\n" +
                "3. Show Costumers\n" +
                "4. Show Account Details";
            Console.WriteLine(menu);

            int a = int.Parse(Console.ReadLine());

            switch (a)
            {
                case 1:
                    addInduvidual();
                     break;
                case 2:
                    addCompany();
                    break;
                case 3:
                    ShowCostumers();
                    break;
                case 4:
                    AccountDetails();
                    break;

            }

        }

        static void AccountDetails()
        {
            Console.WriteLine("Enter Costumer Name");
            string names = Console.ReadLine();

            for (int i = 0; i < induviduals.Count; i++)
            {
                if (names == induviduals[i].name)
                {
                    induviduals[i].DepositAccount(0, 0);
                    induviduals[i].LoanAccount(0);
                    induviduals[i].MortgageAccount(0);
                }
            }
            for (int i = 0; i < companys.Count; i++)
            {
                if (names == companys[i].name)
                {
                    companys[i].DepositAccount(0, 0);
                    companys[i].LoanAccount(0);
                    companys[i].MortgageAccount(0);
                }
            }
            Console.ReadLine();
            Menu();
        }

        static void addInduvidual()
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            induviduals.Add(new Induvidual(name, true, true,true));
            for (int i = 0; i < induviduals.Count; i++)
            {
                accounts.Add(induviduals[i]);
            }
            Console.WriteLine("Added: " + name);
            Console.ReadLine();
            Menu();
        }
        static void addCompany()
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            companys.Add(new Company(name, true, true, true));
            for (int i = 0; i < companys.Count; i++)
            {
                accounts.Add(companys[i]);
            }
            Console.WriteLine("Added: " + name);
            Console.ReadLine();
            Menu();
        }


        static void ShowCostumers()
        {
            foreach (var account in accounts)
            {
                Console.WriteLine(account + "\n------------------\n");
            }
            Console.ReadLine();
            Menu();
        }



    }
}


