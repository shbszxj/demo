using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creation.AbstractFactory
{
    class Program : IDesignPatternDemo
    {
        public string Title => "3.5";

        public string Description => "Abstract factory of Food Example";

        public void Run()
        {
            var africaEcosystem = new Ecosystem(new AfricaFactory());
            africaEcosystem.Run();

            var australiaEcosystem = new Ecosystem(new AustraliaFactory());
            australiaEcosystem.Run();
        }
    }
}
