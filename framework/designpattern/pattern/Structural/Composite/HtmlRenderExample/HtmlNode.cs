using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Structural.Composite.HtmlRenderExample
{
    /// <summary>
	/// The component abstract base class.
	/// </summary>
    abstract class HtmlNode
    {
        /// <summary>
		/// Render the HTML node.
		/// </summary>
		public abstract string Render();
    }
}
