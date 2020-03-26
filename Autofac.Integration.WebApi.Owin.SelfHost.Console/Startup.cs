using System;
using Autofac.Integration.WebApi.Owin.SelfHost.Console.Filters;
using Autofac.Integration.WebApi.Owin.SelfHost.Console.Infrastructure;
using Microsoft.Owin;
using Owin;
using System.Reflection;
using System.Web.Http;
using Autofac.Integration.WebApi.Owin.SelfHost.Console.Books.Domain;
using LiteDB;


[assembly: OwinStartup(typeof(Autofac.Integration.WebApi.Owin.SelfHost.Console.Startup))]

namespace Autofac.Integration.WebApi.Owin.SelfHost.Console
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

            builder
                .RegisterType<LoggingActionFilter>()
                .AsWebApiActionFilterForAllControllers()
                .SingleInstance();

            builder.RegisterType<SimpleMemoryCache<Book>>().SingleInstance();

            builder.Register(c => new LiteDatabase($"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}/test.db"));

            builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepository<>));


            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseWebApi(config);
        }
    }
}
