using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Integration.WCF.Client.NotificationService;
using Newtonsoft.Json;

namespace Autofac.Integration.WCF.Client
{
    public class AcceptNotificationCallback : INotificationServiceCallback
    {
        public void Handle(ApplicationEvent applicationEvent)
        {
            Console.WriteLine($"Receive message {JsonConvert.SerializeObject(applicationEvent)}, HashCode = {GetHashCode()}");
        }

        public void Send(string message)
        {
            Console.WriteLine($"Receive message {message}, HashCode = {GetHashCode()}");
        }
    }
}
