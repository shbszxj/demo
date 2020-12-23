using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creation.Builder.Example
{
    class KidsMenuBuilder : MenuBuilder
    {
        private Menu _menu = new Menu();

        public override void BuildBurgerOrSalad()
        {
            _menu.Add("Burger");
        }

        public override void BuildDessert()
        {
        }

        public override void BuildDrink()
        {
            _menu.Add("Drink");
        }

        public override void BuildFries()
        {
            _menu.Add("Fries");
        }

        public override void BuildToy()
        {
            _menu.Add("Toy");
        }

        public override Menu GetResult()
        {
            return _menu;
        }
    }
}
