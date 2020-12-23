using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Structural.Bridge.ChartingLibraryExample
{
    class Rectangle : Shape
    {
        public Rectangle(DrawApi implementor) : base(implementor)
        {

        }

        public override void Draw()
        {
            _implementor.DrawLine(0, 0, 100, 0);
            _implementor.DrawLine(100, 0, 100, 50);
            _implementor.DrawLine(100, 50, 0, 50);
            _implementor.DrawLine(0, 50, 0, 0);
        }
    }
}
