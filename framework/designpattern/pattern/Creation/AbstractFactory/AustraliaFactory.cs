using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creation.AbstractFactory
{
    class AustraliaFactory : ContinentFactory
    {
        public override Carnivore CreateCarnivore()
        {
            return new Dingo();
        }

        public override Herbivore CreateHerbivore()
        {
            return new Kangaroo();
        }
    }
}
