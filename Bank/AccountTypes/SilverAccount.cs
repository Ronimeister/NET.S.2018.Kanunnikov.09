using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public sealed class SilverAccount : AccountType
    {
        private readonly int _addBonusValue;

        private readonly int _withdrawBonusValue;

        public SilverAccount()
        {
            _addBonusValue = 2;
            _withdrawBonusValue = 2;
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
