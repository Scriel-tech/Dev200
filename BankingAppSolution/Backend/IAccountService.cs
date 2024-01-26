using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public interface IAccountService
    {
        public void openSavingsAccount(long accountId, long amountToDeposit); 
        public void openCurrentAccount(long accountId);
        public void withdraw(long accountId, int amountToWithdraw);
        public void deposit(long accountId, int amountToDeposit);
     
    }

}
