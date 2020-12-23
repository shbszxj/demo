using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace DesignPattern.Structural.Bridge
{
    public class Execise : IDesignPatternDemo
    {
        public string Title => "7.2";

        public string Description => "Bridge - Bridge Execise";

        public void Run()
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<RasterRenderer>().As<IRenderer>().SingleInstance();
            cb.RegisterType<Triangle>();
            using (var container = cb.Build())
            {
                var triangle = container.Resolve<Triangle>();
                WriteLine(triangle);
            }
        }
    }

    public interface IRenderer
    {
        string WhatToRenderAs { get; }
    }

    public class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs => "lines";
    }

    public class RasterRenderer : IRenderer
    {
        public string WhatToRenderAs => "pixels";
    }

    public abstract class Shape
    {
        protected IRenderer _renderer;

        protected string Name { get; set; }

        public Shape(IRenderer renderer)
        {
            _renderer = renderer;
        }

        public override string ToString()
        {
            return $"Drawing {Name} as {_renderer.WhatToRenderAs}";
        }
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer)
        {
            Name = "Triangle";
        }
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer)
        {
            Name = "Square";
        }
    }
}
