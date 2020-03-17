using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Integration.WCF.Service
{
    [ServiceContract]
    public interface INotificationServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void Send(string message);
    }
}
