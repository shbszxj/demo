using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creation.FactoryMethod
{
    class Program : IDesignPatternDemo
    {
        public string Title => "3.6";

        public string Description => "Factory method of Toy Creator Example";

        public void Run()
        {
            ToyCreator creator = null;

            // create a firetruck
            Console.WriteLine("Creating a firetruck toy:");
            creator = new FiretruckCreator();
            creator.MakeToy();
            Console.WriteLine();

            // create a superman
            Console.WriteLine("Creating a superman toy:");
            creator = new SupermanCreator();
            creator.MakeToy();
            Console.WriteLine();
        }
    }
}
