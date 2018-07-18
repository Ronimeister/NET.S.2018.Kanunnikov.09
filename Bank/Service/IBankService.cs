using GeneratorCore;
using Repository;

namespace Bank
{
    public interface IBankService
    {        
        void OpenAccount(AccountHolder holder, AccountFactory accountFactory, INumberGenerator generator);

        void CloseAccount(string accountNumber);

        void SuspendAccount(string accountNumber);

        void UnsuspendAccount(string accountNumber);

        void Deposit(string accountNumber, decimal amount);

        void Withdraw(string accountNumber, decimal amount);

        IRepository Repository { get; }        
    }
}