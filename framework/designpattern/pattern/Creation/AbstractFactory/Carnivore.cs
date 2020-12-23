using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creation.AbstractFactory
{
    abstract class Carnivore
    {
        public abstract void Eat(Herbivore herbivore);
    }
}
