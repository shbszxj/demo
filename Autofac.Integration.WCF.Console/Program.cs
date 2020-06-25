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

namespace Autofac.Integration.WCF.Console
{
    class Program
    {
        private const string BaseAddress = "http://localhost:1010";

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

                HostNotificationService(container, "NotificationService");

                System.Console.WriteLine("Press <Enter> to stop the service.");
                System.Console.ReadLine();

                foreach (var host in Hosts)
                {
                    host.Close();
                }
                Environment.Exit(0);
            }
        }

        private static void HostNotificationService(IContainer container, string name)
        {
            ServiceKnownTypesProvider.KnownTypesAssemblies = new List<Assembly>() { typeof(CustomMessageBus).Assembly };

            var url = $"{BaseAddress}/{name}";
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
            var url = $"{BaseAddress}/{name}";
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
