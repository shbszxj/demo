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

        public int GetCalulation(int a, int b)
        {
            Thread.Sleep(1000);
            return a + b;
        }

        public void TestMethod()
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} This is a test method, Hashcode = {GetHashCode()}");
            _notifier.TestFunction();
        }
    }
}
