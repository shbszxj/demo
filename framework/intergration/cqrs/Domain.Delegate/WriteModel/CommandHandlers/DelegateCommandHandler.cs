using CQRSlite.Commands;
using CQRSlite.Domain;
using Domain.Delegate.WriteModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Delegate.WriteModel.CommandHandlers
{
    public class DelegateCommandHandler : ICommandHandler<CreateDelegate>
    {
        private readonly ISession _session;

        public DelegateCommandHandler(ISession session)
        {
            _session = session;
        }

        public async Task Handle(CreateDelegate message)
        {
            var item = new Domain.Delegate(message.Id, message.Name, message.BirthDate);
            await _session.Add(item);
            await _session.Commit();
        }
    }
}
