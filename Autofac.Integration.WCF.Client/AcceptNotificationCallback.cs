using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Integration.WCF.Client.NotificationService;

namespace Autofac.Integration.WCF.Client
{
    public class AcceptNotificationCallback : INotificationServiceCallback
    {
        public void Send(string message)
        {
            Console.WriteLine($"Receive message {message}, HashCode = {GetHashCode()}");
        }
    }
}
