using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creation.FactoryMethod
{
    class FiretruckCreator : ToyCreator
    {
        protected override Toy CreateToy()
        {
            return new Firetruck();
        }
    }
}
