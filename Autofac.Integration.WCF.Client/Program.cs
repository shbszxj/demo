using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Autofac.Integration.Wcf;
using Autofac.Integration.WCF.Client.TestService;

namespace Autofac.Integration.WCF.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder
                .Register(c => new ChannelFactory<ITestService>(
                    new BasicHttpBinding(),
                    new EndpointAddress("http://localhost:1010/TestService")))
                .SingleInstance();

            builder
                .Register(c => c.Resolve<ChannelFactory<ITestService>>().CreateChannel())
                .As<ITestService>()
                .UseWcfSafeRelease();

            builder.RegisterType<MessageWriter>();

            var container = builder.Build();

            Task.Run(() => Test(container));
            Task.Run(() => Test(container));
            Task.Run(() => Test(container));

            Test(container);

            Console.ReadLine();
        }

        private static void Test(IContainer container)
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var messageWriter = scope.Resolve<MessageWriter>();
                messageWriter.TestMethod();
            }
        }
    }
}
