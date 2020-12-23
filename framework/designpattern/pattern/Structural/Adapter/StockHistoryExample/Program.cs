namespace DesignPattern.Structural.Adapter.StockHistoryExample
{
    class Program : IDesignPatternDemo
    {
        public string Title => "6.3";

        public string Description => "Adapter - Stock history example";

        public void Run()
        {
            new StockApp().ShowStockHistory("AAPL");
        }
    }
}
