using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public abstract class AccountType
    {
        public virtual double DepositBonus { get; }

        public virtual double WithdrawBonus { get; }
    }
}
