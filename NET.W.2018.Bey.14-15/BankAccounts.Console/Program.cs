using System;
using System.Linq;
using BankAccounts.Common.Enumes;
using BankAccounts.Common.Interfaces.Services;
using DependencyResolver;
using Ninject;

namespace BankAccounts.ConsolePl
{
    public class Program
    {
        private static readonly IKernel Resolver;

        static Program()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigurateResolver();
        }

        private static void Main(string[] args)
        {
            IAccountService service = Resolver.Get<IAccountService>();

            service.CreateAccount("Owner1", "Owner1", AccountType.Base);
            service.CreateAccount("Owner2", "Owner2", AccountType.Platinum);
            service.CreateAccount("Owner3", "Owner3", AccountType.Gold);
            service.CreateAccount("Owner4", "Owner4", AccountType.Base);

            var creditNumbers = service.GetAllAccounts().Select(acc => acc.Id).ToList();

            if (creditNumbers.Any())
            {
                foreach (var t in creditNumbers)
                {
                    service.DepositMoney(t, 100);
                }

                foreach (var item in service.GetAllAccounts())
                {
                    Console.WriteLine(item);
                }

                foreach (var t in creditNumbers)
                {
                    service.WithdrawMoney(t, 10);
                }

                foreach (var item in service.GetAllAccounts())
                {
                    Console.WriteLine(item);
                }
            }

            Console.ReadLine();
        }
    }
}
