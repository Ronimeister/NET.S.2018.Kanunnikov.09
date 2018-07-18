using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorCore;
using Repository;

namespace Bank
{
    public sealed class BankService : IBankService
    {        
        #region Fields and properties
        private IRepository _repository;

        public IRepository Repository
        {
            get => _repository;
            set
            {
                _repository = value ?? throw new ArgumentException($"{nameof(Repository)} can't be equal to null!");
            }
        }
        #endregion

        #region Constructors
        public BankService(IRepository repository)
        {
            Repository = repository;
        }
        #endregion

        #region Public API
        public void OpenAccount(AccountHolder holder, AccountFactory accountFactory, INumberGenerator generator)
        {
            Account account = accountFactory.CreateNewAccount(holder, generator);
            if (account.Status == AccountStatus.Closed)
            {
                throw new ArgumentException();
            }

            holder.AddAccount(account);
            Repository.Save(account);
        }

        public void CloseAccount(string accountNumber)
        {
            Account account = Repository.GetByNumber(accountNumber);
            account.Status = AccountStatus.Closed;
        }

        public void SuspendAccount(string accountNumber)
        {            
            Account account = Repository.GetByNumber(accountNumber);
            if (account.Status != AccountStatus.Open)
            {
                throw new ArgumentException();    
            }

            account.Status = AccountStatus.Suspended;
        }

        public void UnsuspendAccount(string accountNumber)
        {
            Account account = Repository.GetByNumber(accountNumber);
            if (account.Status != AccountStatus.Suspended)
            {
                throw new ArgumentException();
            }

            account.Status = AccountStatus.Open;
        }

        public void Deposit(string accountNumber, decimal amount)
        {
            Account account = Repository.GetByNumber(accountNumber);
            account.Deposit(amount);
        }

        public void Withdraw(string accountNumber, decimal amount)
        {
            Account account = Repository.GetByNumber(accountNumber);
            account.Withdraw(amount);
        }
        #endregion
    }
}