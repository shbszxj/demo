using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Structural.Composite.HtmlRenderExample
{
    /// <summary>
	/// The concrete p class.
	/// </summary>
	class P : HtmlTag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlRenderExample.P"/> class.
        /// </summary>
        public P() : base("p")
        {
        }
    }
}
