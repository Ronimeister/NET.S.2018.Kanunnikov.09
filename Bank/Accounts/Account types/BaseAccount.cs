using GeneratorCore;
using System;

namespace Bank
{
    public class BaseAccount : Account
    {
        #region Fields and constants
        private const decimal defaultBenefit = 0.01m;
        #endregion

        #region Constructors
        public BaseAccount(AccountHolder holder , INumberGenerator generator) : base(holder, generator)
        {

        }

        public BaseAccount(AccountHolder holder, INumberGenerator generator, decimal balance) : base(holder, generator, balance)
        {

        }

        public BaseAccount(AccountHolder holder, INumberGenerator generator, decimal balance, int benefitPoints) : base(holder, generator, balance, benefitPoints)
        {

        }
        #endregion

        #region Account overrided methods
        protected override int CalculateBenefitPoint(decimal amount)
            => (int)Math.Round(defaultBenefit * (amount + Balance));

        protected override bool IsValidBalance(decimal balance) => balance >= 0;
        #endregion
    }
}
