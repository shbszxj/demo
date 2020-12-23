using static System.Console;

namespace DesignPattern.Creation.Factories.FactoryMethod
{
    public class FactoryMethod : IDesignPatternDemo
    {
        public string Title => "3.1";

        public string Description => "Factory Method";

        public void Run()
        {
            WriteLine(Point.NewCartesianPoint(1, 2));
        }
    }

    public class Point
    {
        private double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point NewCartesianPoint(double x, double y) => new Point(x, y);

        public static Point NewPolarPoint(double rho, double theta) => null;

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }
}