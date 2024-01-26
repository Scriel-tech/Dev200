using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public interface IAccount
    {
        long Id { get; set; }
        string CustomerNumber { get; set; }
        int Balance { get; }
        void Withdraw(int amount);
        void Deposit(int amount);
    }
}
