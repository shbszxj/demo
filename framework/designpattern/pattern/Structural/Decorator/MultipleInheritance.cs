using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace DesignPattern.Structural.Decorator.MultipleInheritance
{
    public class MultipleInheritance : IDesignPatternDemo
    {
        public string Title => "9.3";

        public string Description => "Decorator - Multiple Inheritance";

        public void Run()
        {
            Dragon dragon = new Dragon();
            dragon.Weight = 100;
            dragon.Fly();
            dragon.Crowl();
        }
    }

    public interface IBird
    {
        void Fly();
        int Weight { get; set; }
    }

    public interface ILizard
    {
        void Crowl();
        int Weight { get; set; }
    }

    public class Bird : IBird
    {
        public int Weight { get; set; }

        public void Fly()
        {
            WriteLine($"Bird fly with Weight {Weight}");
        }
    }

    public class Lizard : ILizard
    {
        public int Weight { get; set; }

        public void Crowl()
        {
            WriteLine($"Lizard crowl with Weight {Weight}");
        }
    }

    public class Dragon : IBird, ILizard
    {
        private int _weight;
        public int Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                _bird.Weight = value;
                _lizard.Weight = value;
            }
        }

        private IBird _bird = new Bird();
        private ILizard _lizard = new Lizard();

        public void Crowl()
        {
            _lizard.Crowl();
        }

        public void Fly()
        {
            _bird.Fly();
        }
    }
}
