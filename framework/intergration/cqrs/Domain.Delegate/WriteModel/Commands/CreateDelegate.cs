using System;

namespace Domain.Delegate.WriteModel.Commands
{
    public class CreateDelegate : BaseCommand
    {
        public Guid Id { get; }
        public string Name { get; }
        public DateTime BirthDate { get; }

        public CreateDelegate(Guid id, string name, DateTime birthDate)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
        }
    }
}
