using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public sealed class BaseAccount : AccountType
    {
        private readonly double _addBonusValue;

        private readonly double _withdrawBonusValue;

        public override double DepositBonus
        {
            get => _addBonusValue;
        }

        public override double WithdrawBonus
        {
            get => _withdrawBonusValue;
        }

        public BaseAccount()
        {
            _addBonusValue = 0.0001;
            _withdrawBonusValue = 0.0001;
        }        
    }
}