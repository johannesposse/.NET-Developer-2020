using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2
{
    abstract class Bank
    {
        protected bool depositAccount { get; set; }
        protected bool loanAccount { get; set; }
        protected bool mortgageAccount { get; set; }

        public Bank (bool depositAccount, bool loanAccount, bool mortgageAccount) 
        {
            this.depositAccount = depositAccount;
            this.loanAccount = loanAccount;
            this.mortgageAccount = mortgageAccount;
        }

        public abstract void DepositAccount(double deposit, double withdraw);
        public abstract void LoanAccount(double deposit);
        public abstract void MortgageAccount(double deposit);
    }
}
