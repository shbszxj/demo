using LiteDB;
using Microsoft.Owin;
using Owin;
using System;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using CQRSLite.Integration.Console.Infrastructure;

[assembly: OwinStartup(typeof(CQRSLite.Integration.Console.Startup))]

namespace CQRSLite.Integration.Console
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });


            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterType<ConsoleLogger>().As<ILogger>().SingleInstance();

            builder.Register(c => new LiteDatabase($"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}/cqrs.db"));


            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseWebApi(config);
        }
    }
}
