using System;
using static System.Console;

namespace DesignPattern.Creation.Prototype.CopyConstructor
{
    public class CopyConstructor : IDesignPatternDemo
    {
        public string Title => "4.2";

        public string Description => "Prototype - Copy Constructor";

        public void Run()
        {
            var john = new Employee("John", new Address("123 London Road", "London", "UK"));
            var chris = new Employee(john)
            {
                Name = "Chris"
            };
            WriteLine(john);
            WriteLine(chris);
        }
    }

    class Employee
    {
        public string Name;
        public Address Address;

        public Employee(string name, Address address)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Address = address ?? throw new ArgumentNullException(paramName: nameof(address));
        }

        public Employee(Employee other)
        {
            Name = other.Name;
            Address = other.Address;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
        }
    }

    class Address
    {
        public string StreetAddress, City, Country;

        public Address(string streetAddress, string city, string county)
        {
            StreetAddress = streetAddress;
            City = city;
            Country = county;
        }

        public Address(Address other)
        {
            StreetAddress = other.StreetAddress;
            City = other.City;
            Country = other.Country;
        }

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(City)}: {City}, {nameof(Country)}: {Country}";
        }
    }
}