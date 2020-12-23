using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace DesignPattern.SOLID
{
    public class DependencyInversionPrinciple : IDesignPatternDemo
    {
        public string Title => "1.5";

        public string Description => "Dependency Inversion Principle";

        public void Run()
        {
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Matt" };

            // low-level module
            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);
        }
    }

    public enum RelationShip
    {
        Parent, Child, Sibling
    }

    public class Person
    {
        public string Name { get; set; }
    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    public class Relationships : IRelationshipBrowser
    {
        private List<(Person, RelationShip, Person)> _relations = new List<(Person, RelationShip, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            _relations.Add((parent, RelationShip.Parent, child));
            _relations.Add((child, RelationShip.Child, parent));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return _relations.Where(x => x.Item1.Name == name && x.Item2 == RelationShip.Parent).Select(x => x.Item3);
        }
    }

    public class Research
    {
        public Research(IRelationshipBrowser browser)
        {
            foreach (var person in browser.FindAllChildrenOf("John"))
            {
                WriteLine($"John has a child called {person.Name}");
            }
        }
    }
}