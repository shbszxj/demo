using System;
using System.ServiceModel;
using System.Threading;

namespace Autofac.Integration.WCF.Service
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerSession, IncludeExceptionDetailInFaults = true)]
    public class TestService : ITestService
    {
        public void TestMethod()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} This is a test method, Hashcode = {GetHashCode()}");
        }
    }
}
