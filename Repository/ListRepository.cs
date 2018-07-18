using System;
using System.Collections.Generic;
using System.Linq;
using Bank;

namespace Repository
{
    public sealed class ListRepository : IRepository
    {
        private static List<Account> _accounts;

        public ListRepository()
        {
            _accounts = new List<Account>();
        }

        public Account GetByNumber(string accountNumber)
        {
            if (string.IsNullOrEmpty(accountNumber))
            {
                throw new ArgumentException($"{nameof(accountNumber)} can't be equal to null or empty!");
            }

            return _accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
        }

        public void Save(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"{nameof(account)} can't be equal to null!");
            }

            if (_accounts.Contains(account))
            {
                throw new ArgumentException($"{nameof(account)} is already in the repository!");
            }

            _accounts.Add(account);
        }            

        public List<Account> ToList()
        {
            List<Account> returned = new List<Account>();
            foreach (Account item in _accounts)
            {
                returned.Add(item);
            }

            return returned;
        }
    }
}