using CQRSlite.Domain;
using Domain.Delegate.ReadModel.Events;
using System;

namespace Domain.Delegate.WriteModel.Domain
{
    public class Delegate : AggregateRoot
    {
        private Delegate() { }

        public Delegate(Guid id, string name, DateTime birthDate)
        {
            Id = id;
            ApplyChange(new DelegateCreated(id, name, birthDate));
        }
    }
}
