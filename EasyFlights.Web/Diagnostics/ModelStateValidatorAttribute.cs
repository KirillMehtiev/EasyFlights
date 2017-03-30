using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace EasyFlights.Web.Diagnostics
{
    public class ModelStateValidatorAttribute : AsyncActionFilterAttribute
    {
        [SuppressMessage("StyleCop.CSharp.AsyncRules",
                    "AR0002:MethodEndingWithAsyncMustHaveAsyncModifier",
                    Justification = "External interface method")]
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (!actionContext.ModelState.IsValid)
            {
                IEnumerable<string> modelErrors = actionContext.ModelState.Values.Select(
                    modelState => modelState.Errors.ToList()).Aggregate(
                        (allErrors, errors) =>
                        {
                            allErrors.AddRange(errors);
                            return allErrors;
                        })
                    .Select(
                        error =>
                        !string.IsNullOrWhiteSpace(error.ErrorMessage) || error.Exception == null
                            ? error.ErrorMessage
                            : "Incorrect input value.");

                string message = string.Join(" ", modelErrors.Distinct());

                HttpResponseMessage response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest);
                response.ReasonPhrase = message;
                actionContext.Response = response;
            }

            return Task.FromResult(true);
        }
    }
}