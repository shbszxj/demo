using CQRSlite.Events;
using System;

namespace CQRSLite.Integration.Console.Employee.ReadModel.Events
{
    public class EmployeeCreated : IEvent
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        public EmployeeCreated(Guid id)
        {
            Id = id;
        }
    }
}
