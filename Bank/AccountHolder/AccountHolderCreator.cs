using System;

namespace Bank
{
    public static class AccountHolderCreator
    {
        private static long _holderId;

        public static AccountHolder CreateNewHolder(string name, string surname, string contactPhone, string email)
            => new AccountHolder(name, surname, contactPhone, email, ++_holderId);
    }
}
