using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Structural.Composite.HtmlRenderExample
{
    class Text : LeafNode
    {
        // the contents of the text node
        protected string _text = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlRenderExample.Text"/> class.
        /// </summary>
        /// <param name="text">Text.</param>
        public Text(string text)
        {
            _text = text;
        }

        /// <summary>
        /// Render the text node.
        /// </summary>
        public override string Render()
        {
            return _text;
        }
    }
}
