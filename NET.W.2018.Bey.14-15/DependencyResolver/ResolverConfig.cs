using System;
using System.Data.Entity;
using BankAccounts.BusinessLogic.Services;
using BankAccounts.Common.BonusAdapter;
using BankAccounts.Common.Interfaces.BonusCounter;
using BankAccounts.Common.Interfaces.Repositories;
using BankAccounts.Common.Interfaces.Services;
using BankAccounts.DataAccess.Context;
using BankAccounts.DataAccess.Repositories;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            Func<decimal, int, int> calcFunc = (amount, type) => (int)amount / (type * 10);

            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IBonusCounter>().To<AdapterBonusCounter>().WithConstructorArgument("calcFunc", calcFunc);
            kernel.Bind<IAccountRepository>().To<AccountRepository>();            
            kernel.Bind<DbContext>().To<BankContext>();
        }
    }
}
