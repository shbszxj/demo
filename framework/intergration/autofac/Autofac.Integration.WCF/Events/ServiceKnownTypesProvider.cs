using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Autofac.Integration.WCF.Service.Events
{
    public static class ServiceKnownTypesProvider
    {
        private static IEnumerable<Assembly> _knownTypesAssemblies;

        public static IEnumerable<Assembly> KnownTypesAssemblies
        {
            get { return _knownTypesAssemblies ?? new[] { typeof(ServiceKnownTypesProvider).Assembly }; }
            set { _knownTypesAssemblies = value; }
        }

        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            return KnownTypesAssemblies.SelectMany(a => a.GetTypes()).Where(x => x.BaseType == typeof(ApplicationEvent)).Distinct();
        }
    }
}
