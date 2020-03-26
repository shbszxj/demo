namespace Autofac.Integration.WebApi.Owin.SelfHost.Console.Infrastructure
{
    public class ConsoleLogger : ILogger
    {
        public void Write(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}
