using GeneratorCore;

namespace Bank
{
    public class SilverAccountFactory : AccountFactory
    {
        public override Account CreateNewAccount(AccountHolder holder, INumberGenerator generator)
           => new SilverAccount(holder, generator);
    }
}
