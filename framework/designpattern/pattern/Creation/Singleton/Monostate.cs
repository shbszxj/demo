using static System.Console;

namespace DesignPattern.Creation.Singleton.Monostate
{
    public class Monostate : IDesignPatternDemo
    {
        /// monostate and singleton are two faces of the same medal (global state):
        ///     monostate forces a behaviour (only one value along all class instances)
        ///         MonoState m1 = new MonoState();
        ///         MonoState m2 = new MonoState(); // same state of m1 
        ///     singleton forces a structural constraint (only one instance)
        ///         Singleton singleton = Singleton.getInstance();
        public string Title => "5.3";

        public string Description => "Singleton - Monostate";

        public void Run()
        {
            var ceo = new ChiefExecutiveOfficer();
            ceo.Name = "Jack Zhou";
            ceo.Age = 30;

            var ceo2 = new ChiefExecutiveOfficer();
            WriteLine(ceo2);
        }
    }

    class ChiefExecutiveOfficer
    {
        private static string name;
        private static int age;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }
}