using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public interface AccountService
    {
        void OpenSavingsAccount(long accountId, long amountToDeposit);
        void OpenCurrentAccount(long accountId);
        void Withdraw(long accountId, int amountToWithdraw);
        void Deposit(long accountId, int amountToDeposit);
    }

}
