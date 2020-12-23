using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creation.AbstractFactory
{
    class Ecosystem
    {
        private Herbivore _herbivore;
        private Carnivore _carnivore;

        public Ecosystem(ContinentFactory factory)
        {
            _herbivore = factory.CreateHerbivore();
            _carnivore = factory.CreateCarnivore();
        }

        public void Run()
        {
            _carnivore.Eat(_herbivore);
        }
    }
}
