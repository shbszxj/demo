using static System.Console;

namespace DesignPattern.Structural.Adapter
{
    public class Execise : IDesignPatternDemo
    {
        public string Title => "6.2";

        public string Description => "Adapter - Execise";

        public void Run()
        {
            var adapter = new SquareToRectangleAdapter(new Square() { Side = 11 });
            WriteLine($"Area = {adapter.Area()}");
        }
    }

    public class Square
    {
        public int Side;
    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        private readonly Square _square;

        public SquareToRectangleAdapter(Square square)
        {
            _square = square;
        }

        public int Width => _square.Side;

        public int Height => _square.Side;
    }

}
