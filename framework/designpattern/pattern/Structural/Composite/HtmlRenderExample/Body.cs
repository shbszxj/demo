using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Structural.Composite.HtmlRenderExample
{
    /// <summary>
	/// The concrete body class.
	/// </summary>
	class Body : HtmlTag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlRenderExample.Body"/> class.
        /// </summary>
        public Body() : base("body")
        {
        }
    }
}
