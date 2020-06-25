using Autofac.Integration.WCF.Service.Events;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Autofac.Integration.WCF.Service
{
    internal class ClientCallbackHandler
    {
        private readonly NotificationService _parent;
        private readonly string _clientId;
        private readonly INotificationServiceCallback _callback;
        private readonly object _thisLock = new object();

        internal ClientCallbackHandler(NotificationService parent, string clientId, INotificationServiceCallback callback)
        {
            _parent = parent;
            _clientId = clientId;
            _callback = callback;
        }

        public Task Handle(ApplicationEvent e)
        {
            return ExecuteCallbackFunction(() =>
            {
                Console.WriteLine($"{e.GetType().Name}: {JsonConvert.SerializeObject(e)}");

                _callback.Handle(e);
            });
        }

        public Task Send(string message)
        {
            return ExecuteCallbackFunction(() =>
            {
                _callback.Send(message);
            });
        }

        public Task ExecuteCallbackFunction(Action action)
        {
            lock (_thisLock)
            {
                if (!_parent.IsSubscribed(_clientId))
                {
                    Console.WriteLine("Client already unsubscribed!");
                };

                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    _parent.Unsubscribe(_clientId);
                }
            }
            return Task.CompletedTask;
        }
    }
}