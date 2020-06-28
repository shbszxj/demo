using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Integration.WCF.Service.Domain
{
    public class Notifier
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly NotificationService _notification;

        public Notifier(IEventPublisher eventPublisher, NotificationService notification)
        {
            _eventPublisher = eventPublisher;
            _notification = notification;
        }

        public Task TestFunction()
        {
            _notification.Callback("Send", $"{DateTime.Now} a new message from server");
            _notification.Callback("SendAnotherMessage", $"{DateTime.Now} another message from server");
            return _eventPublisher.Publish(new NotifierEvent());
            //return Task.CompletedTask;
        }
    }
}
