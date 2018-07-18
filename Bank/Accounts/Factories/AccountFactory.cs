using GeneratorCore;

namespace Bank
{
    public abstract class AccountFactory
    {
        public abstract Account CreateNewAccount(AccountHolder holder, INumberGenerator generator);
    }
}
