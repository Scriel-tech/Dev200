using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class SavingsAccount : IAccount
    {
        private const int MinimumBalance = 1000;

        public long Id { get; set; }
        public string CustomerNumber { get; set; }
        public int Balance { get; private set; }

        public SavingsAccount(long accountId, long amountToDeposit)
        {
            if(amountToDeposit < MinimumBalance)
            {
                throw new MinimumBalanceNotMet("Cannot Create a Savings Account without a minimum deposit of R1000");
            }
            else
            {
                this.Id = accountId;
                Balance = (int)amountToDeposit;
            }
           
        }

        public void Withdraw(int amount)
        {
            if (Balance - amount < MinimumBalance)
            {
                throw new WithdrawalAmountTooLargeException("Cannot withdraw amount, minimum balance requirement not met.");
            }

            Balance -= amount;
        }

        public void Deposit(int amount)
        {
            Balance += amount;
        }
    }
}
