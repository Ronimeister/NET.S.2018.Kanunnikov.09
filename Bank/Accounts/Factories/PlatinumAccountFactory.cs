using GeneratorCore;

namespace Bank
{
    class PlatinumAccountFactory : AccountFactory
    {
        public override Account CreateNewAccount(AccountHolder holder, INumberGenerator generator)
           => new PlatinumAccount(holder, generator);
    }
}
