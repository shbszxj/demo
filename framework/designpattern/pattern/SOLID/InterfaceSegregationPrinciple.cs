using static System.Console;

namespace DesignPattern.SOLID
{
    public class InterfaceSegregationPrinciple : IDesignPatternDemo
    {
        public string Title => "1.4";

        public string Description => "Interface Segregation Principle";

        public void Run()
        {
            WriteLine("Nothing to show ...");
        }
    }

    public class Document
    {

    }

    public interface IMachine
    {
        void Print(Document d);
        void Fax(Document d);
        void Scan(Document d);
    }

    public class OldFashionedPrinter : IMachine
    {
        public void Fax(Document d)
        {
            throw new System.NotImplementedException();
        }

        public void Print(Document d)
        {
            throw new System.NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    public class Printer : IPrinter
    {
        public void Print(Document d)
        {

        }
    }

    public interface IMultiFunctionDevice : IPrinter, IScanner
    {

    }

    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            throw new System.NotImplementedException();
        }

        void IScanner.Scan(Document d)
        {
            throw new System.NotImplementedException();
        }
    }

    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        private IPrinter _printer;
        private IScanner _scanner;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner)
        {
            _printer = printer;
            _scanner = scanner;
        }

        public void Print(Document d)
        {
            _printer.Print(d);
        }

        public void Scan(Document d)
        {
            _scanner.Scan(d);
        }
    }
}