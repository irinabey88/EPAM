using System;
using System.Linq;
using BankAccounts.BusinessLogic.Services;
using BankAccounts.Common.BonusAdapter;
using BankAccounts.Common.Enumes;
using BankAccounts.Common.Interfaces.BonusCounter;
using BankAccounts.Common.Interfaces.Repositories;
using BankAccounts.Common.Interfaces.Services;
using BankAccounts.DataAccess.Repositories;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
        }

        static void Main(string[] args)
        {
            IAccountRepository repository = resolver.Get<AccountRepository>();
            INumberCreatorService creator = resolver.Get<CustomNumberCreatorService>();
            IBonusCounter bonusCounter = resolver.Get<AdapterBonusCounter>();
            IAccountService service = resolver.Get<AccountService>();


            service.CreateAccount("Owner1", "Owner1", AccountType.Base);
            service.CreateAccount("Owner2", "Owner2", AccountType.Platinum);
            service.CreateAccount("Owner3", "Owner3", AccountType.Gold);
            service.CreateAccount("Owner4", "Owner4", AccountType.Base);

            //var accounts = repository.GetAllElements();

            //service.CreateAccount("Owner1", "Owner1", AccountType.Base);
            //service.CreateAccount("Owner2", "Owner2", AccountType.Platinum);
            //service.CreateAccount("Owner3", "Owner3", AccountType.Gold);
            //service.CreateAccount("Owner4", "Owner4", AccountType.Base);

            //var creditNumbers = service.GetAllAccounts().Select(acc => acc.Id);

            //foreach (var t in creditNumbers)
            //{
            //    service.DepositMoney(t, 100);
            //}

            //foreach (var item in service.GetAllAccounts())
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (var t in creditNumbers)
            //{
            //    service.WithdrawMoney(t, 10);
            //}

            //foreach (var item in service.GetAllAccounts())
            //{
            //    Console.WriteLine(item);
            //}

            //Console.ReadLine();
        }
    }
}
