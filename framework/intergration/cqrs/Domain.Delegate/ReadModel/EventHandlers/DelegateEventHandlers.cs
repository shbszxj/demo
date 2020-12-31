using CQRSlite.Events;
using Domain.Delegate.ReadModel.Dtos;
using Domain.Delegate.ReadModel.Events;
using LiteDB;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Delegate.ReadModel.EventHandlers
{
    public class DelegateEventHandlers : ICancellableEventHandler<DelegateCreated>
    {
        private ILiteCollection<DelegateDto> _delegateCollection;

        public DelegateEventHandlers()
        {
            _delegateCollection = new LiteDatabase("cqrs.db").GetCollection<DelegateDto>();
        }

        public Task Handle(DelegateCreated message, CancellationToken token = default)
        {
            _delegateCollection.Insert(new DelegateDto(message.Id, message.Name, message.BirthDate, message.Version));
            return Task.CompletedTask;
        }
    }
}
