using System.Xml.Linq;
using BLL.DataCreator;
using BLL.DataReceiver;
using BLL.Interface.Interfaces;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            var fileName = @"D:\EPAM_HOME\Test\uri.txt";
            kernel.Bind<IDataReceiver<string>>().To<TxtFileReceiver>().WithConstructorArgument("fileName", fileName);
            kernel.Bind<IDataCreator<string, XElement>>().To<DataFileCreator>();                      
        }
    }
}
