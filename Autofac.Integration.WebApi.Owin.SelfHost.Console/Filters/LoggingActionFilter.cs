using Autofac.Integration.WebApi.Owin.SelfHost.Console.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Autofac.Integration.WebApi.Owin.SelfHost.Console.Filters
{
    public class LoggingActionFilter : IAutofacActionFilter
    {
        private readonly ILogger _logger;

        public LoggingActionFilter(ILogger logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            _logger.Write($"Response : {await actionExecutedContext.Response.Content.ReadAsStringAsync()}");
        }

        public Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            _logger.Write($"Request : {actionContext.ControllerContext.Request}");
            return Task.FromResult(0);
        }
    }
}
