using static System.Console;

namespace DesignPattern.Creation.Prototype.IClonable
{
    public class ImplementIClonable : IDesignPatternDemo
    {
        public string Title => "4.1";

        public string Description => "IClonable is bad";

        public void Run()
        {
            var john = new Person(new[] { "John", "Smith" }, new Address("London Road", 123));

            var jane = (Person)john.Clone();
            jane.Address.HouseNumber = 321; // oops, John is now at 321

            // this doesn't work
            //var jane = john;

            // but clone is typically shallow copy
            jane.Names[0] = "Jane";

            WriteLine(john);
            WriteLine(jane);
        }
    }

    class Person
    {
        public string[] Names;

        public Address Address;

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(",", Names)}, {nameof(Address)}: {Address}";
        }

        public object Clone()
        {
            return new Person(Names, (Address)Address.Clone());
        }
    }

    class Address
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public object Clone()
        {
            return new Address(StreetName, HouseNumber);
        }
    }
}