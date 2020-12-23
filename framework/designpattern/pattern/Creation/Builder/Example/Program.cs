using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creation.Builder.Example
{
    class Program : IDesignPatternDemo
    {
        public string Title => "2.5";

        public string Description => "Builder - Fast food example";

        public void Run()
        {
            var director = new MenuDirector();
            var burgerMenuBuilder = new BurgerMenuBuilder();
            director.Construct(burgerMenuBuilder);
            Console.WriteLine($"Burger menu: {burgerMenuBuilder.GetResult()}");

            var kidsMenuBuilder = new KidsMenuBuilder();
            director.Construct(kidsMenuBuilder);
            Console.WriteLine($"Kids menu: {kidsMenuBuilder.GetResult()}");
        }
    }
}
