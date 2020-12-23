using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Example.Member.WriteModel
{
    public class InMemoryEventStore : IEventStore
    {
        public Task<IEnumerable<IEvent>> Get(Guid aggregateId, int fromVersion, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Save(IEnumerable<IEvent> events, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
