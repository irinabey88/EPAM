using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Fake.Repositories;
using DAL.Interface.Interfaces;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IAccountRepository>().To<AccountRepository>();            
            kernel.Bind<INumberCreatorService>().To<NumberCreatorService>().InSingletonScope();
        }
    }
}
