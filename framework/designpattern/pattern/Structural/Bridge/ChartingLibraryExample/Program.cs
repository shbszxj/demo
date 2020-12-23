using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Structural.Bridge.ChartingLibraryExample
{
    class Program : IDesignPatternDemo
    {
        public string Title => "7.3";

        public string Description => "Bridge - Charting library example";

        public void Run()
        {
            // draw a line
            Console.WriteLine("Line drawn using OpenGL commands:");
            Shape line = new Line(new OpenGLApi());
            line.Draw();
            Console.WriteLine();

            // draw a rectangle
            Console.WriteLine("Rectangle drawn using SVG commands:");
            Shape rectangle = new Rectangle(new SvgApi());
            rectangle.Draw();
            Console.WriteLine();
        }
    }
}
