using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creation.Builder.Example
{
    class MenuDirector
    {
        public void Construct(MenuBuilder builder)
        {
            builder.BuildBurgerOrSalad();
            builder.BuildFries();
            builder.BuildDessert();
            builder.BuildDrink();
            builder.BuildToy();
        }
    }
}
