using System.ServiceModel;

namespace Autofac.Integration.WCF.Service
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        void TestMethod();
    }
}
