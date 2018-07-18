using System;
using GeneratorCore;

namespace Bank
{
    public abstract class Account
    {
        #region Private fields
        private string _accountNumber;

        private AccountHolder _holder;
        #endregion

        #region Properties
        public decimal Balance { get; private set; }

        public int BenefitPoints { get; private set; }

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

        public AccountHolder Holder
        {
            get => _holder;
            set
            {
                _holder = value ?? throw new ArgumentException($"{nameof(Holder)} can't be equal to null!");
            }
        }

        public AccountStatus Status { get; set;}
        #endregion

        #region Constructors
        public Account(AccountHolder holder, INumberGenerator generator)
        {
            Holder = holder;
            AccountNumber = generator.GenerateAccountNumber();
            Status = AccountStatus.Open;
        }

        public Account(AccountHolder holder, INumberGenerator generator, decimal balance )
        {
            Holder = holder;
            AccountNumber = generator.GenerateAccountNumber();
            Balance = balance;
            Status = AccountStatus.Open;
        }

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
        public override string ToString()
        {
            return $" Type: {GetType()}\n" + $" ID: {_accountNumber}\n" + $" Status: {Status}\n" + 
                $" Holder: {_holder}\n" + $" Balance: {Balance}\n" + $" Benefits: {BenefitPoints}";
        }

        public void Deposit(decimal amount)
        {
            if (Status != AccountStatus.Open)
            {
                throw new ArgumentException();
            }

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount can not be less or equal to zero.");
            }

            Balance += amount;
            BenefitPoints += CalculateBenefitPoint(amount);
        }

        public void Withdraw(decimal amount)
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
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount can't be less or equal to zero.");
            }

            if (amount > Balance)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount can't be bigger than balance!");
            }

            Balance -= amount;
            BenefitPoints -= CalculateBenefitPoint(amount) / 2;
        }
        #endregion

        #region Private API
        protected abstract int CalculateBenefitPoint(decimal amount);

        protected abstract bool IsValidBalance(decimal balance);
        #endregion
    }
}