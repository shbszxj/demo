using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creation.Builder.Example
{
    class SaladMenuBuilder : MenuBuilder
    {
        private Menu _menu = new Menu();

        public override void BuildBurgerOrSalad()
        {
            _menu.Add("Salad");
        }

        public override void BuildDessert()
        {
            _menu.Add("Dessert");
        }

        public override void BuildDrink()
        {
            _menu.Add("Drink");
        }

        public override void BuildFries()
        {
        }

        public override void BuildToy()
        {
        }

        public override Menu GetResult()
        {
            return _menu;
        }
    }
}
