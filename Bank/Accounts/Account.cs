using System;
using GeneratorCore;

namespace Bank
{
    /// <summary>
    /// Abstract class described bank Account
    /// </summary>
    public abstract class Account
    {
        #region Private fields
        private string _accountNumber;

        private AccountHolder _holder;
        #endregion

        #region Properties
        /// <summary>
        /// Describe this <see cref="Account"/> object balance
        /// </summary>
        public decimal Balance { get; private set; }

        /// <summary>
        /// Describe this <see cref="Account"/> object benefit points
        /// </summary>
        public int BenefitPoints { get; private set; }

        /// <summary>
        /// Describe this <see cref="Account"/> object account number
        /// </summary>
        /// <exception cref="ArgumentException">Throws when set value is equal to null or empty</exception> 
        public string AccountNumber
        {
            get => _accountNumber;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(AccountNumber)} can't be equal to null or empty!");
                }
                _accountNumber = value;
            }
        }

        /// <summary>
        /// Describe this <see cref="Account"/> object account holder
        /// </summary>
        /// <exception cref="ArgumentException">Throws when set value is equal to null</exception>
        public AccountHolder Holder
        {
            get => _holder;
            private set
            {
                _holder = value ?? throw new ArgumentException($"{nameof(Holder)} can't be equal to null!");
            }
        }

        /// <summary>
        /// Describe this <see cref="Account"/> object status
        /// </summary>
        public AccountStatus Status { get; set;}
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for <see cref="Account"/> class
        /// </summary>
        /// <param name="holder"><see cref="AccountHolder"/> object represented holder of this account</param>
        /// <param name="generator"><see cref="INumberGenerator"/> object represented how account number of this account should be generated</param>
        public Account(AccountHolder holder, INumberGenerator generator)
        {
            Holder = holder;
            AccountNumber = generator.GenerateAccountNumber();
            Status = AccountStatus.Open;
        }

        /// <summary>
        /// Constructor for <see cref="Account"/> class
        /// </summary>
        /// <param name="holder"><see cref="AccountHolder"/> object represented holder of this account</param>
        /// <param name="generator"><see cref="INumberGenerator"/> object represented how account number of this account should be generated</param>
        /// <param name="balance"><see cref="decimal"/> value of start account balance</param>
        public Account(AccountHolder holder, INumberGenerator generator, decimal balance )
        {
            Holder = holder;
            AccountNumber = generator.GenerateAccountNumber();
            Balance = balance;
            Status = AccountStatus.Open;
        }

        /// <summary>
        /// Constructor for <see cref="Account"/> class
        /// </summary>
        /// <param name="holder"><see cref="AccountHolder"/> object represented holder of this account</param>
        /// <param name="generator"><see cref="INumberGenerator"/> object represented how account number of this account should be generated</param>
        /// <param name="balance"><see cref="decimal"/> value of start account balance</param>
        /// <param name="benefitPoints"><see cref="int"/> value represented benefit points of this account</param>
        public Account(AccountHolder holder, INumberGenerator generator, decimal balance, int benefitPoints)
        {
            Holder = holder;
            AccountNumber = generator.GenerateAccountNumber();
            Balance = balance;
            BenefitPoints = benefitPoints;
            Status = AccountStatus.Open;
        }
        #endregion

        #region Public API
        /// <summary>
        /// Overrided <see cref="System.Object.ToString"/> method that return string representation of this account fields
        /// </summary>
        /// <returns>string representation of this account fields</returns>
        public override string ToString()
        {
            return $" Type: {GetType().Name}\n" + $" ID: {_accountNumber}\n" + $" Status: {Status}\n" + 
                $" Holder: {_holder}\n" + $" Balance: {Balance}\n" + $" Benefits: {BenefitPoints}";
        }

        /// <summary>
        /// Method represented deposit operation on this account
        /// </summary>
        /// <param name="amount"><see cref="decimal"/> amount of deposited value</param>
        /// <exception cref="ArgumentException">Throws when <paramref name="amount"/> is less or equal to zero</exception>
        internal void Deposit(decimal amount)
        {
            if (Status != AccountStatus.Open)
            {
                throw new ArgumentException(); /// Сделать кастомный эксепшн
            }

            if (amount <= 0)
            {
                throw new ArgumentException(nameof(amount), "Deposit amount can not be less or equal to zero.");
            }

            Balance += amount;
            BenefitPoints += CalculateBenefitPoint(amount);
        }

        /// <summary>
        /// Method represented withdraw operation on this account
        /// </summary>
        /// <param name="amount"><see cref="decimal"/> amount of withdrawed value</param>
        /// <exception cref="ArgumentException">Throws when <paramref name="amount"/> is less or equal to zero  or  bigger than <see cref="Balance"/></exception>
        internal void Withdraw(decimal amount)
        {
            if (Status != AccountStatus.Open)
            {
                throw new ArgumentException();
            }

            if (!IsValidBalance(Balance))
            {
                throw new ArgumentException();
            }

            if (amount <= 0)
            {
                throw new ArgumentException(nameof(amount), "Deposit amount can't be less or equal to zero.");
            }

            if (amount > Balance)
            {
                throw new ArgumentException(nameof(amount), "Deposit amount can't be bigger than balance!");
            }

            Balance -= amount;
            BenefitPoints -= CalculateBenefitPoint(amount) / 2;
        }
        #endregion

        #region Private methods
        protected abstract int CalculateBenefitPoint(decimal amount);

        protected abstract bool IsValidBalance(decimal balance);
        #endregion
    }
}
