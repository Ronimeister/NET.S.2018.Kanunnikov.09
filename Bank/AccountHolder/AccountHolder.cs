using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Bank
{
    /// <summary>
    /// Class representing person attached to account
    /// </summary>
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
        /// <summary>
        /// Represent holder's name
        /// </summary>
        /// <exception cref="ArgumentException">Throws when setted value is equal to null, empty or started not with uppercase letter</exception>
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

        /// <summary>
        /// Represent holder's surname
        /// </summary>
        /// <exception cref="ArgumentException">Throws when setted value is equal to null, empty or started not with uppercase letter</exception> 
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

        /// <summary>
        /// Represent holder's contact phone
        /// </summary>
        /// <exception cref="ArgumentException">Throws when setted value is equal to null, empty or not in form of phone</exception> 
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

        /// <summary>
        /// Represent holder's contact email
        /// </summary>
        /// <exception cref="ArgumentException">Throws when setted value is equal to null, empty or not in form of email</exception> 
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

        /// <summary>
        /// Constructor for <see cref="AccountHolder"/> class
        /// </summary>
        /// <param name="name">Holder's name</param>
        /// <param name="surname">Holder's surname</param>
        /// <param name="contactPhone">Holder's contact phone</param>
        /// <param name="email">Holder's email</param>
        /// <param name="holderId">Holder's ID</param>
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
        /// <summary>
        /// Check if two <see cref="AccountHolder"/> objects are equal
        /// </summary>
        /// <param name="other"><see cref="AccountHolder"/> object to compare with</param>
        /// <returns>bool value</returns>
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

        /// <summary>
        /// <see cref="System.Object.Equals(object)"/> overrided method that check if two objects are equal
        /// </summary>
        /// <param name="obj"><see cref="System.Object"/> object to compare with</param>
        /// <returns>bool value</returns>
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

        /// <summary>
        /// <see cref="System.Object.Equals(object)"/> overrided method that return hash code for this instance
        /// </summary>
        /// <returns>hash code for this instance</returns>
        public override int GetHashCode() => _holderId.GetHashCode() ^ 199;

        /// <summary>
        /// <see cref="System.Object.Equals(object)"/> overrided method that return string representation of this instance
        /// </summary>
        /// <returns>string representation of this instance</returns>
        public override string ToString()
        {
            return $"(Name: {_name} | Surname: {_surname} | Contact phone: {_contactPhone} | Email: {_email} | Id: {_holderId})";
        }
        #endregion

        #region Public API
        /// <summary>
        /// Add created account to holder account's list
        /// </summary>
        /// <param name="account">Current instance of holder</param>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="account"/> is equal to null.</exception>
        public void AddAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"{nameof(account)} can't be equal to null!");
            }

            _holderAccounts.Add(account);
        }

        /// <summary>
        /// Return <see cref="IEnumerable{Account}"/> representation of all current holder accounts
        /// </summary>
        /// <returns><see cref="IEnumerable{Account}"/> representation of all current holder accounts</returns>
        public IEnumerable<Account> GetAllAccount()
            => _holderAccounts.Where(x => x.Holder._holderId == _holderId);
        #endregion
    }
}
