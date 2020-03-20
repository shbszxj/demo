using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Integration.WebApi.Owin.SelfHost.Console.Books.Domain
{
    public class Book
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

    }
}
