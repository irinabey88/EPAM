using System;
using System.Linq;
using BLL.Interface.Enumes;
using BLL.Interface.Interfaces;
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
            IAccountService service = resolver.Get<IAccountService>();
            INumberCreatorService creator = resolver.Get<INumberCreatorService>();

            service.CreateAccount("Owner1", "Owner1", AccountType.Base);
            service.CreateAccount("Owner2", "Owner2", AccountType.Platinum);
            service.CreateAccount("Owner3", "Owner3", AccountType.Gold);
            service.CreateAccount("Owner4", "Owner4", AccountType.Base);

            var creditNumbers = service.GetAllAccounts().Select(acc => acc.Number);

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

            Console.ReadLine();
        }
    }
}
