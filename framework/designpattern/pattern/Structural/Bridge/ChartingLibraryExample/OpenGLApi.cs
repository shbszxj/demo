using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Structural.Bridge.ChartingLibraryExample
{
    /// <summary>
	/// The concrete implementor class for an OpenGL drawing API.
	/// </summary>
    class OpenGLApi : DrawApi
    {
        public override void DrawLine(int x1, int y1, int x2, int y2)
        {
            Console.WriteLine(@"glBegin(GL_LINES)");
            Console.WriteLine(@"glVertex2i({0},{1})", x1, y1);
            Console.WriteLine(@"glVertex2i({0},{1})", x2, y2);
            Console.WriteLine(@"glEnd()");
        }
    }
}
