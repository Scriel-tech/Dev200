using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class BankAccountService : AccountService
    {
        //private readonly SystemDB systemDB;

        public BankAccountService()
        {
            systemDB = SystemDB.Instance;
        }

        public void OpenSavingsAccount(long accountId, long amountToDeposit)
        {
            systemDB.Accounts.Add(new SavingsAccount(accountId, amountToDeposit));
        }

        public void OpenCurrentAccount(long accountId)
        {
            systemDB.Accounts.Add(new CurrentAccount(accountId));
        }

        public void Withdraw(long accountId, int amountToWithdraw)
        {
            var account = systemDB.Accounts.Find(a => a.Id == accountId);

            if (account == null)
            {
                throw new AccountNotFoundException("Account not found.");
            }

            account.Withdraw(amountToWithdraw);
        }

        public void Deposit(long accountId, int amountToDeposit)
        {
            var account = systemDB.Accounts.Find(a => a.Id == accountId);

            if (account == null)
            {
                throw new AccountNotFoundException("Account not found.");
            }

            account.Deposit(amountToDeposit);
        }

        public IAccount GetAccountById(long accountId)
        {
            var account = systemDB.Accounts.Find(a => a.Id == accountId);

            return account;
        }
    }
}
