using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Structural.Bridge.ChartingLibraryExample
{
    /// <summary>
	/// The redefined abstraction class. 
	/// </summary>
    class Line : Shape
    {
        /// <summary>
		/// Initializes a new instance of the <see cref="BridgePattern.Line"/> class.
		/// </summary>
		/// <param name="implementor">The implementor instance to use.</param>
        public Line(DrawApi implementor) : base(implementor)
        {
        }

        public override void Draw()
        {
            _implementor.DrawLine(0, 0, 100, 100);
        }
    }
}
