using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Autofac.Integration.Wcf;
using Autofac.Integration.WCF.Client.NotificationService;
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

            builder.RegisterType<AcceptNotificationCallback>().AsImplementedInterfaces().SingleInstance();

            builder
                .Register(c => new DuplexChannelFactory<INotificationService>(
                    new InstanceContext(c.Resolve<INotificationServiceCallback>()),
                    new NetTcpBinding(SecurityMode.None, true)
                    {
                        OpenTimeout = TimeSpan.FromMinutes(1),
                        SendTimeout = TimeSpan.FromMinutes(1),
                        CloseTimeout = TimeSpan.FromMinutes(1),
                        ReceiveTimeout = TimeSpan.FromMinutes(1)
                    },
                    new EndpointAddress("net.tcp://localhost:1011/NotificationService")))
                .SingleInstance();

            builder
                .Register(c => c.Resolve<DuplexChannelFactory<INotificationService>>().CreateChannel())
                .As<INotificationService>()
                .UseWcfSafeRelease();

            builder.RegisterType<MessageWriter>();

            var container = builder.Build();

            //Task.Run(() => Test(container));
            //Task.Run(() => Test(container));
            //Task.Run(() => Test(container));

            Test(container);

            Console.ReadLine();
        }

        private static void Test(IContainer container)
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var messageWriter = scope.Resolve<MessageWriter>();
                messageWriter.Subscribe();

                messageWriter.TestMethod();
                //messageWriter.TestNotificationMethod();
                //messageWriter.TestNotificationMethod();

                messageWriter.Unsubscribe();
            }
        }
    }
}
