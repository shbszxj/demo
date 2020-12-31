using CQRSlite.Events;
using System;

namespace Domain.Delegate.ReadModel.Events
{
    public class BaseEvent : IEvent
    {
        public Guid Id { get; set; }

        public int Version { get; set; }

        public DateTimeOffset TimeStamp { get; set; }

        public BaseEvent()
        {
            TimeStamp = DateTimeOffset.UtcNow;
        }
    }
}
