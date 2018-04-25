using System;
using System.Xml.Linq;
using BLL.DataConverter;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;

namespace ConsoleXMlCreator
{
    class Program
    {
        private static readonly IKernel _resolver;
        private static readonly string _fileName;

        static Program()
        {
            _resolver = new StandardKernel();
            _resolver.ConfigurateResolver();
        }

        static void Main(string[] args)
        {            
            var xmlConverter = new UriStringToXmlConverter(_resolver.Get<IDataReceiver<string>>(),
                _resolver.Get<IDataCreator<string, XElement>>());

            var xmlResult = xmlConverter.Convert();
            Console.WriteLine(xmlResult);

            Console.ReadLine();
        }
    }
}
