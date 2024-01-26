using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class CurrentAccount : IAccount
    {
        public int OverdraftLimit = 100000;

        public long Id { get; set; }
        public string CustomerNumber { get; set; }
        public int Balance { get; set; }

        public CurrentAccount(long accountId) 
        { 
            this.Id = accountId;
        }

        public void Withdraw(int amount)
        {
            if (Balance + OverdraftLimit - amount < 0)
            {
                throw new WithdrawalAmountTooLargeException("Cannot withdraw amount, exceeds overdraft limit.");
            }

            Balance -= amount;
        }

        public void Deposit(int amount)
        {
            Balance += amount;
        }
    }
}
