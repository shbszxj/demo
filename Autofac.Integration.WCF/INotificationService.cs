using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Integration.WCF.Service
{
    [ServiceContract(CallbackContract = typeof(INotificationServiceCallback))]
    public interface INotificationService
    {
        [OperationContract]
        void TestCallbackMethod();

        [OperationContract]
        void Subscribe(string client);

        [OperationContract]
        void KeepAlive();

        [OperationContract]
        void Unsubscribe(string client);
    }
}
