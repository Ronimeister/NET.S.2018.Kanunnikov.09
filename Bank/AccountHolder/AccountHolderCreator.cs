namespace Bank
{
    /// <summary>
    /// Abstract class that creates new <see cref="AccountHolder"/> object
    /// </summary>
    public static class AccountHolderCreator
    {
        private static long _holderId;

        /// <summary>
        /// Creates new <see cref="AccountHolder"/> object
        /// </summary>
        /// <param name="name"><see cref="AccountHolder"/> object <see cref="AccountHolder.Name"/> value</param>
        /// <param name="surname"><see cref="AccountHolder"/> object <see cref="AccountHolder.Surname"/> value<</param>
        /// <param name="contactPhone"><see cref="AccountHolder"/> object <see cref="AccountHolder.ContactPhone"/> value<</param>
        /// <param name="email"><see cref="AccountHolder"/> object <see cref="AccountHolder.Email"/> value<</param>
        /// <returns>new <see cref="AccountHolder"/> object</returns>
        public static AccountHolder CreateNewHolder(string name, string surname, string contactPhone, string email)
            => new AccountHolder(name, surname, contactPhone, email, ++_holderId);
    }
}
