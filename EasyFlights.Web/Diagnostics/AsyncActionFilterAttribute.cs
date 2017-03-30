using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EasyFlights.Web.Diagnostics
{
    public abstract class AsyncActionFilterAttribute : FilterAttribute, IActionFilter
    {
        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            await OnActionExecutingAsync(actionContext, cancellationToken);

            if (actionContext.Response != null)
            {
                return actionContext.Response;
            }

            HttpActionExecutedContext executedContext;

            HttpResponseMessage response = await continuation();
            executedContext = new HttpActionExecutedContext(actionContext, null) { Response = response };

            await OnActionExecutedAsync(executedContext, cancellationToken);

            return executedContext.Response;
        }

        public async virtual Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            await Task.FromResult(true);
        }

        public async virtual Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            await Task.FromResult(true);
        }
    }
}