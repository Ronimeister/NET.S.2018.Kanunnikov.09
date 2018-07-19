using GeneratorCore;
using System;

namespace Bank
{
    /// <summary>
    /// Class representing base account 
    /// </summary>
    public class BaseAccount : Account
    {
        #region Fields and constants
        private const decimal defaultBenefit = 0.01m;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for <see cref="BaseAccount"/>
        /// </summary>
        /// <param name="holder"><see cref="AccountHolder"/> object represented holder of this account</param>
        /// <param name="generator"><see cref="INumberGenerator"/> object represented how account number of this account should be generated</param>
        public BaseAccount(AccountHolder holder , INumberGenerator generator) : base(holder, generator)
        {

        }

        /// <summary>
        /// Constructor for <see cref="BaseAccount"/>
        /// </summary>
        /// <param name="holder"><see cref="AccountHolder"/> object represented holder of this account</param>
        /// <param name="generator"><see cref="INumberGenerator"/> object represented how account number of this account should be generated</param>
        /// <param name="balance"><see cref="decimal"/> value of start account balance</param>
        public BaseAccount(AccountHolder holder, INumberGenerator generator, decimal balance) : base(holder, generator, balance)
        {

        }

        /// <summary>
        /// Constructor for <see cref="BaseAccount"/>
        /// </summary>
        /// <param name="holder"><see cref="AccountHolder"/> object represented holder of this account</param>
        /// <param name="generator"><see cref="INumberGenerator"/> object represented how account number of this account should be generated</param>
        /// <param name="balance"><see cref="decimal"/> value of start account balance</param>
        /// <param name="benefitPoints"><see cref="int"/> value represented benefit points of this account</param>
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
