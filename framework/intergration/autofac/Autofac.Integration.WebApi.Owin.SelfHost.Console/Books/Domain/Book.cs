using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Integration.WebApi.Owin.SelfHost.Console.Infrastructure;

namespace Autofac.Integration.WebApi.Owin.SelfHost.Console.Books.Domain
{
    public class Book : IEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

    }
}
