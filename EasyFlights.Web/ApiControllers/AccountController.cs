using System.Web.Http;
using EasyFlights.Web.ViewModels.AccountViewModels;

namespace EasyFlights.Web.ApiControllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        [Route("register")]
        [HttpPost]
        public IHttpActionResult Register([FromBody]RegisterViewModel model)
        {
            return this.Ok();
        }
    }
}
