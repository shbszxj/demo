using System;

namespace Autofac.Integration.WCF.Service.Events
{
    public class DependencyResolver : IServiceProvider
    {
        private readonly IContainer _container;

        public DependencyResolver(IContainer container)
        {
            _container = container;
        }

        public object GetService(Type type)
        {
            return _container.Resolve(type);
        }
    }
}
