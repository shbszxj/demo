using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace DesignPattern.Structural.Proxy.ProtectionProxy
{
    public class ProtectionProxy : IDesignPatternDemo
    {
        public string Title => "12.1";

        public string Description => "Proxy - Protection Proxy";

        public void Run()
        {
            var car = new CarProxy(new Driver(12));
            car.Drive();
        }
    }

    public interface ICar
    {
        void Drive();
    }

    public class Car : ICar
    {
        public void Drive()
        {
            WriteLine("Car being driven");
        }
    }
    public class Driver
    {
        public int Age { get; set; }

        public Driver(int age)
        {
            Age = age;
        }
    }

    public class CarProxy : ICar
    {
        private ICar _car = new Car();
        private Driver _driver;

        public CarProxy(Driver driver)
        {
            _driver = driver;
        }

        public void Drive()
        {
            if (_driver.Age < 16)
            {
                WriteLine("too young to drive");
            }
            else
            {
                _car.Drive();
            }
        }
    }
}
