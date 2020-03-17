using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Integration.WCF.Client.TestService;

namespace Autofac.Integration.WCF.Client
{
    public class MessageWriter
    {
        private readonly ITestService _testService;

        public MessageWriter(ITestService service)
        {
            _testService = service;
        }

        public void TestMethod()
        {
            Console.WriteLine($"Call TestService TestMethod, HashCode = {GetHashCode()}, Service HashCode = {_testService.GetHashCode()}");
            _testService.TestMethod();
        }
    }
}
