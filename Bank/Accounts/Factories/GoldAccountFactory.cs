using GeneratorCore;

namespace Bank
{
    class GoldAccountFactory : AccountFactory
    {
        public override Account CreateNewAccount(AccountHolder holder, INumberGenerator generator)
           => new GoldAccount(holder, generator);
    }
}
