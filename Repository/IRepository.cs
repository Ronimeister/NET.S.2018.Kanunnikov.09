using Bank;
using System.Collections.Generic;

namespace Repository
{
    public interface IRepository
    {
        void Save(Account account);

        Account GetByNumber(string accountNumber);

        //void Update();

        List<Account> ToList();
    }
}
