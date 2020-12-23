using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Integration.WebApi.Owin.SelfHost.Console.Infrastructure
{
    public interface IEntity
    {
        string Id { get; set; }
    }
}
