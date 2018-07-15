using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BankAccount
    {
        #region Fields and properties
        private Person _accountOwner;

        private AccountType _accountType;

        public Guid Id { get; private set; }

        public decimal Balance { get; private set; }
        
        public int BonusPoints { get; private set; }
        #endregion

        #region Constructors
        public BankAccount(Person owner)
        {
            if (owner is null)
            {
                throw new ArgumentNullException($"{nameof(owner)} can't be equal to null!");
            }

            Id = Guid.NewGuid();
            _accountOwner = owner;
            _accountType = new BaseAccount();
        }

        public BankAccount(Person owner, AccountType accountType)
        {
            if (owner is null)
            {
                throw new ArgumentNullException($"{nameof(owner)} can't be equal to null!");
            }

            if (accountType is null)
            {
                throw new ArgumentNullException($"{nameof(accountType)} can't be equal to null!");
            }

            Id = Guid.NewGuid();
            _accountOwner = owner;
            _accountType = accountType;
        }
        #endregion

        #region Public API
        public override string ToString()
        {
            return $"Account owner: {_accountOwner.Name} {_accountOwner.Surname} | Account ID: {Id} | Balance: {Balance.ToString()} | Bonus points: {BonusPoints.ToString()};";
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException($"{nameof(amount)} can't be less then 0!");
            }
            
            if (Balance == decimal.MaxValue)
            {
                throw new ArgumentException($"{nameof(Balance)} can't be increased because it equals to decimal.MaxValue!");
            }

            DepositAmount(amount);
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException($"{nameof(amount)} can't be less then 0!");
            }

            if (Balance == 0 || Balance - amount < 0)
            {
                throw new ArgumentException($"{nameof(amount)} can't be withdrawed because {nameof(Balance)} will be less than 0!");
            }

            WithdrawAmount(amount);
        }
        #endregion

        #region Private API
        private void DepositAmount(decimal amount)
        {
            Balance += amount;
            BonusPoints += (int)((double)amount * _accountType.DepositBonus);
        }

        private void WithdrawAmount(decimal amount)
        {
            int earnedBonus = (int)((double)amount * _accountType.DepositBonus);

            if (BonusPoints - earnedBonus < 0)
            {
                BonusPoints = 0;
            }

            Balance -= amount;
            BonusPoints -= earnedBonus;
        }
        #endregion
    }
}
