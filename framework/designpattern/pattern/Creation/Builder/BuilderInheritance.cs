using static System.Console;

namespace DesignPattern.Creation.Builder.BuilderInheritance
{
    public class BuilderInheritance : IDesignPatternDemo
    {
        public string Title => "2.2";

        public string Description => "Builder Inheritance";

        public void Run()
        {
            var builder = new PersonBuilder();
            var person = builder.Called("Jack").WorksAsA("Engineer").Build();
            WriteLine(person);
        }
    }

    class Person
    {
        public string Name, Position;

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    class PersonBuilder : PersonJobBuilder<PersonBuilder>
    {

    }

    abstract class PersonBuilder<SELF> where SELF : PersonBuilder<SELF>
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }

    class PersonInfoBuilder<SELF> : PersonBuilder<PersonInfoBuilder<SELF>>
        where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

    class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>>
        where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }
}