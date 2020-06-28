using Autofac.Integration.WCF.Service.Domain;
using System;
using System.ServiceModel;
using System.Threading;

namespace Autofac.Integration.WCF.Service
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall, IncludeExceptionDetailInFaults = true)]
    public class TestService : ITestService
    {
        private readonly Notifier _notifier;

        public TestService(Notifier notifier)
        {
            _notifier = notifier;
        }

        public void TestMethod()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} This is a test method, Hashcode = {GetHashCode()}");
            _notifier.TestFunction();
        }
    }
}
