using static System.Console;

namespace DesignPattern.Creation.Factories.InnerFactory
{
    public class InnerFactory : IDesignPatternDemo
    {
        public string Title => "3.2";

        public string Description => "Inner Factory";

        public void Run()
        {
            WriteLine(Point.Factory.NewCartesianPoint(1, 2));
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

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y) => new Point(x, y);

            public static Point NewPolarPoint(double rho, double theta) => null;
        }
    }
}