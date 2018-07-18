using GeneratorCore;
using System;

namespace Bank
{
    class SilverAccount : Account
    {
        #region Fields and constants
        private const decimal defaultBenefit = 0.05m;
        #endregion

        #region Constructors
        public SilverAccount(AccountHolder holder, INumberGenerator generator) : base(holder, generator)
        {

        }

        public SilverAccount(AccountHolder holder, INumberGenerator generator, decimal balance) : base(holder, generator, balance)
        {

        }

        public SilverAccount(AccountHolder holder, INumberGenerator generator, decimal balance, int benefitPoints) : base(holder, generator, balance, benefitPoints)
        {

        }
        #endregion

        #region Account overrided methods
        protected override int CalculateBenefitPoint(decimal amount)
            => (int)Math.Round(defaultBenefit * (amount + Balance));

        protected override bool IsValidBalance(decimal balance) => balance >= -100;
        #endregion
    }
}
