using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DesignPattern.Structural.Proxy
{
    public class ValueProxy : IDesignPatternDemo
    {
        public string Title => "12.3";

        public string Description => "Proxy - Value Proxy";

        public void Run()
        {
            var p1 = 10f * 5.Percent();
            Console.WriteLine(p1);
            Percentage p2 = 2.Percent() + 3.Percent();
            Console.WriteLine(p2);
        }
    }

    [DebuggerDisplay("{_value*100.0f}%")]
    public struct Percentage
    {
        private readonly float _value;

        internal Percentage(float value)
        {
            _value = value;
        }

        public static float operator *(float f, Percentage p)
        {
            return f * p._value;
        }
        
        public static Percentage operator + (Percentage a, Percentage b)
        {
            return new Percentage(a._value + b._value);
        }

        public override string ToString()
        {
            return $"{_value * 100}%";
        }
    }

    public static class PercentageExtensions
    {
        public static Percentage Percent(this int value)
        {
            return new Percentage(value / 100.0f);
        }

        public static Percentage Percent(this float value)
        {
            return new Percentage(value / 100.0f);
        }
    }

}
