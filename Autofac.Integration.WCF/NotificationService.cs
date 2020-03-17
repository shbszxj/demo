using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Autofac.Integration.WCF.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class NotificationService : INotificationService
    {
        INotificationServiceCallback Callback => OperationContext.Current.GetCallbackChannel<INotificationServiceCallback>();

        public void TestCallbackMethod()
        {
            string message = $"Thread {Thread.CurrentThread.ManagedThreadId} This is a callback method, HashCode = {GetHashCode()}";
            Console.WriteLine(message);
            Callback.Send(message);
        }
    }
}
