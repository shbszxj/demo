namespace CQRSLite.Integration.Console.Infrastructure
{
    public class ConsoleLogger : ILogger
    {
        public void Write(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}
