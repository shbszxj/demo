using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRSlite.Domain;
using CQRSLite.Integration.Console.Employee.ReadModel.Events;

namespace CQRSLite.Integration.Console.Employee.WriteModel.Domain
{
    public class Employee : AggregateRoot
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime DateCreated { get; set; }

        public Gender Gender { get; set; }

        public Address Address { get; set; }

        public Employee()
        {

        }

        public Employee(string name, int age, Gender gender, Address address)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            DateCreated = DateTime.UtcNow;
            Gender = gender;
            Address = address;

            ApplyChange(new EmployeeCreated(Id));
        }
    }
}
