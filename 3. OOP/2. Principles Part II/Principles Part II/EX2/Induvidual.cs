using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2
{
    class Induvidual : Bank, IintrestRate
    {
        public string name { get; private set; }
        protected double balance { get; private set; }

        public double numberOfMonths { get; set; }
        public double interestRate { get; set; }

        public Induvidual(string name, bool depositAccount, bool loanAccount, bool mortgageAccount) : base(depositAccount, loanAccount, mortgageAccount)
        {
            this.name = name;
        }

        public override void DepositAccount(double _deposit, double _withdraw)
        {
            if (depositAccount == true)
            {
                DateTime created = Convert.ToDateTime("2020, 07, 18");
                this.name = name;
                double deposit = _deposit;
                double withdraw = _withdraw;

                if (this.balance < 0 & withdraw > 0)
                {
                    Console.WriteLine("Cant withdraw money, your balance is less than 0\n-----------------------------\n");
                }
                else
                {
                    List<double> tempBalance = new List<double>();
                    this.balance = this.balance + deposit;
                    if (withdraw > this.balance)
                    {
                        Console.WriteLine($"Name: {this.name}\nAccount: Deposit\nCreated: {created}\nBalance: {this.balance}\nYou dont have enough money in your account to withdraw: {withdraw}\n-----------------------------\n");
                    }
                    else
                    {
                        this.balance = this.balance - withdraw;
                        tempBalance.Add(this.balance);
                        this.balance = tempBalance.Last();
                        if (this.balance > 0 & this.balance < 1000)
                        {
                            this.interestRate = 0;
                            Console.WriteLine($"Name: {this.name}\nAccount: Deposit\nCreated: {created}\nBalance: {this.balance}\nInterest Rate: {this.interestRate}\nDeposited: {deposit}\nWithdrawn: {withdraw}\n-----------------------------\n");
                        }
                        else
                        {
                            DateTime now = DateTime.Now;
                            numberOfMonths = (now - created).TotalDays;
                            numberOfMonths = numberOfMonths / 31;
                            numberOfMonths = Math.Round(numberOfMonths, 0);

                            interestRate = 1.006;
                            for (int i = 0; i < numberOfMonths; i++)
                            {
                                this.balance = (this.balance * interestRate);
                            }
                            this.balance = Math.Round(this.balance, 2);
                            this.interestRate = (this.interestRate - 1) * 10;
                            this.interestRate = Math.Round(this.interestRate, 2);

                            Console.WriteLine($"Name: {this.name}\nAccount: Deposit\nCreated: {created}\nBalance: {this.balance}\nInterest Rate: {this.interestRate}\nDeposited: {deposit}\nWithdrawn: {withdraw}\n-----------------------------\n");
                        }
                    }
                }
            }
        }

        public override void LoanAccount(double _deposit)
        {
            if (loanAccount == true)
            {
                this.balance = 1000;
                DateTime created = Convert.ToDateTime("2020, 01, 18");
                this.name = name;
                double deposit = _deposit;

                if (this.balance < 0)
                {
                    Console.WriteLine("Your loan has been paid off\n-----------------------------\n");
                }
                else
                {
                    DateTime now = DateTime.Now;
                    numberOfMonths = (now - created).TotalDays;
                    numberOfMonths = numberOfMonths / 31;
                    numberOfMonths = Math.Round(numberOfMonths, 0);

                    List<double> tempBalance = new List<double>();
                    this.balance = this.balance - deposit;
                    tempBalance.Add(this.balance);
                    this.balance = tempBalance.Last();
                    if (deposit > this.balance)
                    {
                        Console.WriteLine($"Name: {this.name}\nAccount: Loan\nCreated: {created}\nYour loan has been paid off\n-----------------------------\n");
                    }
                    else
                    {
                        if (numberOfMonths < 3)
                        {
                            this.interestRate = 0;
                            Console.WriteLine($"Name: {this.name}\nAccount: Loan\nCreated: {created}\nBalance: -{this.balance}\nInterest Rate: {this.interestRate}\nDeposited: {deposit}\n-----------------------------\n");
                        }
                        else
                        {
                            interestRate = 1.03;
                            for (int i = 0; i < numberOfMonths; i++)
                            {
                                this.balance = (this.balance * interestRate);
                            }
                            this.balance = Math.Round(this.balance, 2);
                            this.interestRate = (this.interestRate - 1) * 10;
                            this.interestRate = Math.Round(this.interestRate, 2);

                            Console.WriteLine($"Name: {this.name}\nAccount: Loan\nCreated: {created}\nBalance: -{this.balance}\nInterest Rate: {this.interestRate}\nDeposited: {deposit}\n-----------------------------\n");
                        }
                    }
                }
            }
        }

        public override void MortgageAccount(double _deposit)
        {
            if (mortgageAccount == true)
            {
                this.balance = 3200000;
                DateTime created = Convert.ToDateTime("2020, 01, 18");
                this.name = name;
                double deposit = _deposit;

                if (this.balance < 0)
                {
                    Console.WriteLine("Your loan has been paid off\n-----------------------------\n");
                }
                else
                {
                    DateTime now = DateTime.Now;
                    numberOfMonths = (now - created).TotalDays;
                    numberOfMonths = numberOfMonths / 31;
                    numberOfMonths = Math.Round(numberOfMonths, 0);

                    List<double> tempBalance = new List<double>();
                    this.balance = this.balance - deposit;
                    tempBalance.Add(this.balance);
                    this.balance = tempBalance.Last();
                    if (deposit > this.balance)
                    {
                        Console.WriteLine($"Name: {this.name}\nAccount: Mortgage\nCreated: {created}\nYour loan has been paid off\n-----------------------------\n");
                    }
                    else
                    {
                        if (numberOfMonths < 6)
                        {
                            this.interestRate = 0;
                            Console.WriteLine($"Name: {this.name}\nAccount: Mortgage\nCreated: {created}\nBalance: -{this.balance}\nInterest Rate: {this.interestRate}\nDeposited: {deposit}\n-----------------------------\n");
                        }
                        else
                        {
                            interestRate = 1.004;
                            for (int i = 0; i < numberOfMonths; i++)
                            {
                                this.balance = (this.balance * interestRate);
                            }
                            this.balance = Math.Round(this.balance, 2);
                            this.interestRate = (this.interestRate - 1) * 10;
                            this.interestRate = Math.Round(this.interestRate, 2);

                            Console.WriteLine($"Name: {this.name}\nAccount: Mortgage\nCreated: {created}\nBalance: -{this.balance}\nInterest Rate: {this.interestRate}\nDeposited: {deposit}\n-----------------------------\n");
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"Name: {this.name}\nDeposit Account: {this.depositAccount}\nLoan Account: {this.loanAccount}\nMortgage Account: {this.mortgageAccount}\n";
        }

    }
}
