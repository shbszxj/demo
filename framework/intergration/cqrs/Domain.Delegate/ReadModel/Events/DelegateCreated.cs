using System;

namespace Domain.Delegate.ReadModel.Events
{
    public class DelegateCreated : BaseEvent
    {
        public string Name { get; }
        public DateTime BirthDate { get; }

        public DelegateCreated(Guid id, string name, DateTime birthDate)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
        }
    }
}
