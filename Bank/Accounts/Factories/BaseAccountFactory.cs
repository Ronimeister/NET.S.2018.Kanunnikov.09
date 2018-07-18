using GeneratorCore;

namespace Bank
{
    public class BaseAccountFactory : AccountFactory
    {
        public override Account CreateNewAccount(AccountHolder holder, INumberGenerator generator)
            => new BaseAccount(holder, generator);
    }
}
