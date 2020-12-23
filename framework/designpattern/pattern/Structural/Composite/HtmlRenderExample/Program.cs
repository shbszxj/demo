using System;

namespace DesignPattern.Structural.Composite.HtmlRenderExample
{
    class Program : IDesignPatternDemo
    {
        public string Title => "8.3";

        public string Description => "Composite - Html render example";

        public void Run()
        {
            // create a simple html document
            var html = new Html();
            var body = new Body();
            var p = new P();
            var text = new Text("Hello World");
            p.AddChild(text);
            body.AddChild(p);
            html.AddChild(body);

            // render the document to the console
            Console.WriteLine(html.Render());
        }
    }
}
