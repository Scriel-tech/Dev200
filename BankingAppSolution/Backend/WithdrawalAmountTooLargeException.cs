using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{ 
    public class WithdrawalAmountTooLargeException : Exception
    {
        public WithdrawalAmountTooLargeException(string message) : base(message)
        {
        }
    }
}
