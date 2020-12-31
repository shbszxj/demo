using CQRSlite.Events;
using Domain.Delegate.WriteModel.CommandHandlers;
using Domain.Delegate.WriteModel.Commands;
using Domain.Test.TestHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Domain.Test.Delegate.WriteModel
{
    public class WhenDelegateCreated : Specification<Domain.Delegate.WriteModel.Domain.Delegate, DelegateCommandHandler, CreateDelegate>
    {
        private Guid _id;

        protected override DelegateCommandHandler BuildHandler()
        {
            return new DelegateCommandHandler(Session);
        }

        protected override IEnumerable<IEvent> Given()
        {
            _id = Guid.NewGuid();
            return new List<IEvent>();
        }

        protected override CreateDelegate When()
        {
            return new CreateDelegate(_id, "Jack", new DateTime(1989, 6, 15));
        }

        [Then]
        public void Should_create_one_event()
        {
            Assert.Equal(1, PublishedEvents.Count);
        }
    }
}
