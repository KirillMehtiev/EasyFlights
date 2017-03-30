using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace EasyFlights.Web.Diagnostics
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public void Handle(ExceptionHandlerContext context)
        {
            context.Result = new InternalServerErrorResult(context.Request);
        }
        [SuppressMessage("StyleCop.CSharp.AsyncRules",
            "AR0002:MethodEndingWithAsyncMustHaveAsyncModifier",
            Justification = "External interface method")]
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            var exception = context.Exception as HttpResponseException;

            if (exception != null)
            {
                var exceptionMessage = new HttpResponseMessage { ReasonPhrase = exception.Response.ReasonPhrase, StatusCode = exception.Response.StatusCode };
                context.Result = new ResponseMessageResult(exceptionMessage);
                return Task.FromResult(true);
            }

            context.Result = new InternalServerErrorResult(context.Request);
            return Task.FromResult(true);
        }

        public bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }
    }
}