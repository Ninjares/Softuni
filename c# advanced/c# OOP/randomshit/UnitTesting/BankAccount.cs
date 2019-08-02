using System;
using System.Collections.Generic;
using System.Text;

namespace RandomShit
{
    public class BankAccount
    {
        private decimal balance;
        public decimal Balance
        {
            get => balance;
            set
            {
                if (value >= 0) balance = value;
                else throw new ArgumentException("Balance cannot be negative");
            }
        }

        public BankAccount(decimal balance)
        {
            Balance = balance;
        }
        public void Deposit(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentException("Sum must be a positive nymber");
            }
            else Balance += sum;
        }

        
    }
}
