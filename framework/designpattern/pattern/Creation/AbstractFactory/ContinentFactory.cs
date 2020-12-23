using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creation.AbstractFactory
{
    abstract class ContinentFactory
    {
        public abstract Carnivore CreateCarnivore();

        public abstract Herbivore CreateHerbivore();
    }
}
