using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.AccountTypes
{
    public sealed class PlatinumAccount : AccountType
    {
        private readonly int _addBonusValue;

        private readonly int _withdrawBonusValue;

        public PlatinumAccount()
        {
            _addBonusValue = 4;
            _withdrawBonusValue = 4;
        }

        public override double DepositBonus
        {
            get => _addBonusValue;
        }

        public override double WithdrawBonus
        {
            get => _withdrawBonusValue;
        }
    }
}
