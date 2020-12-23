using System;
using Autofac;
using static System.Console;

namespace DesignPattern.Creation.Singleton
{
    public class SingletonInDI : IDesignPatternDemo
    {
        public string Title => "5.2";

        public string Description => "Singleton - Singleton In Dependency Injection";

        public void Run()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EventBroker>().As<IEventBroker>().SingleInstance();
            builder.RegisterType<Foo>();

            using (var container = builder.Build())
            {
                var foo1 = container.Resolve<Foo>();
                var foo2 = container.Resolve<Foo>();

                WriteLine(ReferenceEquals(foo1, foo2));
                WriteLine(ReferenceEquals(foo1.Broker, foo2.Broker));
            }
        }
    }

    interface IEventBroker
    {

    }

    class EventBroker : IEventBroker
    {

    }

    class Foo
    {
        public IEventBroker Broker;

        public Foo(IEventBroker broker)
        {
            Broker = broker ?? throw new ArgumentNullException(paramName: nameof(broker));
        }
    }
}