using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.AccountTypes
{
    public sealed class GoldAccount : AccountType
    {
        private readonly int _addBonusValue;

        private readonly int _withdrawBonusValue;

        public GoldAccount()
        {
            _addBonusValue = 3;
            _withdrawBonusValue = 3;
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
