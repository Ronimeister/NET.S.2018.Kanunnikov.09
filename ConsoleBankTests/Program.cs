using System;
using System.Collections.Generic;
using System.Linq;
using Repository;
using GeneratorCore;
using Bank;

namespace ConsoleBankTests
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository repository = new ListRepository();
            BankService service = new BankService(repository);


            AccountHolder holder = AccountHolderCreator.CreateNewHolder("Alexey", "Kanunnikov", "+8 (029) 370-4492", "ronimeisterhs@gmail.com");
            AccountHolder holder2 = AccountHolderCreator.CreateNewHolder("Alexey", "Prokhorov", "+8 (029) 370-4492", "romanhs@gmail.com");

            service.OpenAccount(holder, new BaseAccountFactory(), new GuidAccountGenerator());
            service.OpenAccount(holder2, new SilverAccountFactory(), new GuidAccountGenerator());

            IEnumerable<Account> holdersA = holder.GetAllAccount();
            foreach (Account a in holdersA)
            {
                Console.WriteLine();
                a.Deposit(120);
                a.Withdraw(11);
                Console.WriteLine(a.ToString());
            }

            string number = holder.GetAllAccount().First().AccountNumber;
            service.SuspendAccount(number);

            List<Account> allAccounts = repository.ToList();
            foreach (Account i in allAccounts)
            {
                Console.WriteLine();
                Console.WriteLine(i.ToString());
            }
        }
    }
}
