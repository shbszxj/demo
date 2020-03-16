using Autofac.Integration.WCF.Service;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using Autofac.Core;
using Autofac.Integration.Wcf;

namespace Autofac.Integration.WCF.Console
{
    class Program
    {
        private const string BaseAddress = "http://localhost:1010/TestService";

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TestService>().As<ITestService>();

            using (var container = builder.Build())
            {
                ServiceHost host = new ServiceHost(typeof(TestService), new Uri(BaseAddress));
                host.AddServiceEndpoint(typeof(ITestService), new BasicHttpBinding(), string.Empty);

                host.AddDependencyInjectionBehavior<ITestService>(container);

                host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true, HttpGetUrl = new Uri(BaseAddress) });

                host.Open();

                System.Console.WriteLine($"The service is ready at {BaseAddress}");
                System.Console.WriteLine("Press <Enter> to stop the service.");
                System.Console.ReadLine();

                host.Close();
                Environment.Exit(0);
            }



            //using (ServiceHost host = new ServiceHost(typeof(TestService), new Uri(BaseAddress)))
            //{
            //    ServiceMetadataBehavior smb = new ServiceMetadataBehavior { HttpGetEnabled = true, MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 } };
            //    host.Description.Behaviors.Add(smb);

            //    host.Open();

            //    System.Console.WriteLine($"The service is ready at {BaseAddress}");
            //    System.Console.WriteLine("Press <Enter> to stop the service.");
            //    System.Console.ReadLine();

            //    host.Close();
            //    Environment.Exit(0);
            //}
        }
    }
}
