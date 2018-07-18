using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Bank
{
    public sealed class AccountHolder : IEquatable<AccountHolder>
    {
        #region Private fields
        private string _name;

        private string _surname;

        private string _email;

        private string _contactPhone;

        private readonly long _holderId;

        private static List<Account> _holderAccounts;
        #endregion

        #region Properties
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(Name)} can't be equal to null or empty!");
                }

                if (!Regex.IsMatch(value, @"[A-Z]+[a-zA-Z]*"))
                {
                    throw new ArgumentException($"{nameof(Name)} must be started with uppercase letter!");
                }

                _name = value;
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(Surname)} can't be equal to null or empty!");
                }

                if (!Regex.IsMatch(value, @"[A-Z]+[a-zA-Z]*"))
                {
                    throw new ArgumentException($"{nameof(Surname)} must be started with uppercase letter!");
                }

                _surname = value;
            }
        }

        public string ContactPhone
        {
            get => _contactPhone;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(ContactPhone)} can't be equal to null or empty!");
                }

                if (!Regex.IsMatch(value, @"^\+\d \(\d{3}\) \d{3}-\d{4}$"))
                {
                    throw new ArgumentException($"{nameof(ContactPhone)} must be in form \"+X (XXX) XXX-XXXX\".");
                }

                _contactPhone = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(Email)} can't be equal to null or empty!");
                }

                if (!Regex.IsMatch(value, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$"))
                {
                    throw new ArgumentException($"{nameof(Email)} must be in form \"name@email.com\".");
                }

                _email = value;
            }
        }
        #endregion

        public AccountHolder(string name, string surname, string contactPhone, string email, long holderId)
        {
            Name = name;
            Surname = surname;
            ContactPhone = contactPhone;
            Email = email;
            _holderId = holderId;
            _holderAccounts = new List<Account>();
        }

        #region IEquetable and System.Object overrided methods
        public bool Equals(AccountHolder other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return _holderId == other._holderId && _name == other._name && _surname == other._surname;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return Equals((AccountHolder) obj);
        }

        public override int GetHashCode() => _holderId.GetHashCode() ^ 199;

        public override string ToString()
        {
            return $"(Name: {_name} | Surname: {_surname} | Contact phone: {_contactPhone} | Email: {_email} | Id: {_holderId})";
        }
        #endregion

        #region Public API
        public void AddAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException();
            }

            _holderAccounts.Add(account);
        }

        public IEnumerable<Account> GetAllAccount()
            => _holderAccounts.Where(x => x.Holder._holderId == _holderId);
        #endregion
    }
}