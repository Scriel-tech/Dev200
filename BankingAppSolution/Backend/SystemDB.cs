using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class SystemDB
    {
        private static readonly SystemDB instance = new SystemDB();

        public static SystemDB Instance => instance;

        public List<IAccount> Accounts { get; private set; }

        private SystemDB()
        {
            // Initialize with hardcoded accounts
            Accounts = new List<IAccount>
        {
            new SavingsAccount(1, 2000),
            new SavingsAccount(2, 5000),
            new CurrentAccount(3) { Balance = 1000, OverdraftLimit = 10000 },
            new CurrentAccount(4) { Balance = -5000, OverdraftLimit = 20000 }
        };
        }
    }
}
