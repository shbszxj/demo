using System;

namespace Domain.Delegate.ReadModel.Dtos
{
    public class DelegateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Location { get; set; }
        public int Version { get; set; }

        public DelegateDto(Guid id, string name, DateTime birthDate, int version)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Version = version;
        }
    }
}
