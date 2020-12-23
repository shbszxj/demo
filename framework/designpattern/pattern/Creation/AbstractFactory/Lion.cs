using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creation.AbstractFactory
{
    class Lion : Carnivore
    {
        public override void Eat(Herbivore herbivore)
        {
            Console.WriteLine($"{this.GetType().Name} eats {herbivore.GetType().Name}");
        }
    }
}
