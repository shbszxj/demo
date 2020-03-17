using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Autofac;

[assembly: OwinStartup(typeof(Autofac.Integration.Owin.SelfHost.Console.Startup))]

namespace Autofac.Integration.Owin.SelfHost.Console
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FirstMiddleware>().InstancePerRequest();


            var container = builder.Build();

            app.UseAutofacMiddleware(container);
            app.UseAutofacLifetimeScopeInjector(container);

            app.UseErrorPage();

            app.Run(context =>
            {
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello, world.");
            });
        }
    }
}
