using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creation.FactoryMethod
{
    class DuckCreator : ToyCreator
    {
        protected override Toy CreateToy()
        {
            return new Duck();
        }
    }
}
