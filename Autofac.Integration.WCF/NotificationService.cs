using Autofac.Integration.WCF.Service.Events;
using CQRSlite.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Autofac.Integration.WCF.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class NotificationService : INotificationService, IEventHandler<ApplicationEvent>
    {
        private readonly ConcurrentDictionary<string, ClientCallbackHandler> _subscribers;

        public NotificationService()
        {
            _subscribers = new ConcurrentDictionary<string, ClientCallbackHandler>();
        }
        public void Subscribe(string clientId)
        {
            Console.WriteLine("Client subscribing");
            if (!IsSubscribed(clientId))
            {
                _subscribers[clientId] = new ClientCallbackHandler(this, clientId, OperationContext.Current.GetCallbackChannel<INotificationServiceCallback>());
            }
        }

        public bool IsSubscribed(string clientId)
        {
            return _subscribers.ContainsKey(clientId);
        }

        public void KeepAlive()
        {
            Console.WriteLine("Client KeepAlive received");
        }

        public void Unsubscribe(string clientId)
        {
            Console.WriteLine("Client unsubscribing");
            if (IsSubscribed(clientId))
            {
                ClientCallbackHandler client;
                if (!_subscribers.TryRemove(clientId, out client))
                {
                    Console.WriteLine("Unable to remove subscriber");
                }
            }
        }

        public Task Handle(ApplicationEvent message)
        {
            foreach (var client in _subscribers.Values)
            {
                client.Handle(message);
            }
            return Task.CompletedTask;
        }

        public void TestCallbackMethod()
        {
            foreach (var client in _subscribers.Values)
            {
                var message = $"Thread {Thread.CurrentThread.ManagedThreadId} This is a callback method, HashCode = {GetHashCode()}";
                Console.WriteLine(message);
                client.Send(message);
            }
        }
    }
}
