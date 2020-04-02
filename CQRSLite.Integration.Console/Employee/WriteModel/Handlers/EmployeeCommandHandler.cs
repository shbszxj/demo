using CQRSlite.Commands;
using CQRSlite.Domain;
using CQRSLite.Integration.Console.Employee.WriteModel.Commands;
using System;
using System.Threading.Tasks;

namespace CQRSLite.Integration.Console.Employee.WriteModel.Handlers
{
    public class EmployeeCommandHandler : ICommandHandler<CreateEmployee>
    {
        private readonly ISession _session;

        public EmployeeCommandHandler(ISession session)
        {
            _session = session;
        }

        public async Task Handle(CreateEmployee message)
        {
            await _session.Add(new Domain.Employee
            {
                Name = message.Name,
                Age = message.Age,
                Address = message.Address,
                DateCreated = DateTime.UtcNow,
                Gender = message.Gender,
            });
            await _session.Commit();
        }
    }
}
