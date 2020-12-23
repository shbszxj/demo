using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Structural.Composite.HtmlRenderExample
{
    /// <summary>
	/// The concrete Html class.
	/// </summary>
	class Html : HtmlTag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlRenderExample.Html"/> class.
        /// </summary>
        public Html() : base("html")
        {
        }
    }
}
