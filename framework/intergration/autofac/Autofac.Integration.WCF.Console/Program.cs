using Autofac.Integration.Wcf;
using Autofac.Integration.WCF.Service;
using Autofac.Integration.WCF.Service.Domain;
using Autofac.Integration.WCF.Service.Events;
using CQRSlite.Commands;
using CQRSlite.Events;
using CQRSlite.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Discovery;

namespace Autofac.Integration.WCF.Console
{
    class Program
    {
        private const string HttpAddress = "http://localhost:1010";
        private const string NetTcpAddress = "net.tcp://localhost:1011";

        private static readonly ICollection<ServiceHost> Hosts = new List<ServiceHost>();

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CustomMessageBus>().SingleInstance();
            builder.Register(c => c.Resolve<CustomMessageBus>()).As<ICommandSender>();
            builder.Register(c => c.Resolve<CustomMessageBus>()).As<IEventPublisher>();
            builder.Register(c => c.Resolve<CustomMessageBus>()).As<IHandlerRegistrar>();

            builder.RegisterType<Notifier>().SingleInstance();

            builder.RegisterType<TestService>().As<ITestService>().SingleInstance();
            builder.RegisterType<NotificationService>().SingleInstance();

            using (var container = builder.Build())
            {
                var bus = new RouteRegistrar(new DependencyResolver(container));

                var types = typeof(CustomMessageBus).Assembly.GetExportedTypes()
                    .Where(type => type.GetInterfaces().Contains(typeof(IHandlerRegistrar)));

                bus.RegisterInAssemblyOf(types.ToArray());

                HostService<ITestService>(container, "TestService");

                //HostNotificationService(container, "NotificationService");

                HostNotificationServiceViaNetTcp(container, "NotificationService");

                System.Console.WriteLine("Press <Enter> to stop the service.");
                System.Console.ReadLine();

                foreach (var host in Hosts)
                {
                    host.Close();
                }
                Environment.Exit(0);
            }
        }

        private static void HostNotificationServiceViaNetTcp(IContainer container, string name)
        {
            ServiceKnownTypesProvider.KnownTypesAssemblies = new List<Assembly>() { typeof(CustomMessageBus).Assembly };

            var url = $"{NetTcpAddress}/{name}";
            ServiceHost host = new ServiceHost(container.Resolve<NotificationService>(), new Uri(url));

            host.AddServiceEndpoint(typeof(INotificationService), new NetTcpBinding(SecurityMode.None, true)
            {
                SendTimeout = TimeSpan.FromSeconds(5)
            }, "");

            //Behaviors (metadata/errorhandling/discovery)
            var serviceBehavior = new ServiceMetadataBehavior { HttpGetEnabled = false };
            host.Description.Behaviors.Add(serviceBehavior);
            host.Description.Behaviors.Add(new ServiceDiscoveryBehavior());

            //Endpoints (metadata/discovery)
            host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
            host.AddServiceEndpoint(new UdpDiscoveryEndpoint());

            host.Open();

            System.Console.WriteLine($"The {name} is ready at {url}");

            Hosts.Add(host);
        }

        private static void HostNotificationService(IContainer container, string name)
        {
            ServiceKnownTypesProvider.KnownTypesAssemblies = new List<Assembly>() { typeof(CustomMessageBus).Assembly };

            var url = $"{HttpAddress}/{name}";
            ServiceHost host = new ServiceHost(container.Resolve<NotificationService>(), new Uri(url));

            host.AddServiceEndpoint(typeof(INotificationService), new WSDualHttpBinding(WSDualHttpSecurityMode.None), string.Empty);

            host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true, HttpGetUrl = new Uri(url) });

            host.Open();

            System.Console.WriteLine($"The {name} is ready at {url}");

            Hosts.Add(host);
        }

        private static void HostService<TInterface>(IContainer container, string name)
        {
            var instance = container.Resolve<TInterface>();
            var url = $"{HttpAddress}/{name}";
            ServiceHost host = new ServiceHost(instance.GetType(), new Uri(url));

            host.AddServiceEndpoint(typeof(TInterface), new BasicHttpBinding(), string.Empty);

            host.AddDependencyInjectionBehavior<TInterface>(container);

            host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true, HttpGetUrl = new Uri(url) });

            host.Open();

            System.Console.WriteLine($"The {name} is ready at {url}");

            Hosts.Add(host);
        }

    }
}
