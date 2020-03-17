using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Autofac.Integration.WCF.Client.NotificationService;
using Autofac.Integration.WCF.Client.TestService;

namespace Autofac.Integration.WCF.Client
{
    public class MessageWriter
    {
        private readonly ITestService _testService;
        private readonly INotificationService _notificationService;

        public MessageWriter(ITestService testService, INotificationService notificationService)
        {
            _testService = testService;
            _notificationService = notificationService;
        }

        public void TestMethod()
        {
            Console.WriteLine($"Call TestService TestMethod, HashCode = {GetHashCode()}, Service HashCode = {_testService.GetHashCode()}");
            _testService.TestMethod();
        }

        public void TestNotificationMethod()
        {
            _notificationService.TestCallbackMethod();
        }
    }
}
