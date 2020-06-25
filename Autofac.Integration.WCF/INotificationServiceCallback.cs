using Autofac.Integration.WCF.Service.Events;
using System.ServiceModel;

namespace Autofac.Integration.WCF.Service
{
    [ServiceContract]
    public interface INotificationServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void Send(string message);

        [OperationContract(IsOneWay = true)]
        void SendAnotherMessage(string message);

        [OperationContract(IsOneWay = true)]
        [ServiceKnownType("GetKnownTypes", typeof(ServiceKnownTypesProvider))]
        void Handle(ApplicationEvent applicationEvent);
    }
}
