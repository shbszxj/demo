using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Integration.WCF.Service
{
    [ServiceBehavior]
    public class TestService : ITestService
    {
        public void TestMethod()
        {
            Console.WriteLine("This is a test method");
        }
    }
}
