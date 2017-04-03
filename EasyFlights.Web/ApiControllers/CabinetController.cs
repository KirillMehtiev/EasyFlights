using System.Web.Http;

namespace EasyFlights.Web.ApiControllers
{
    [RoutePrefix("api/Cabinet")]
    public class CabinetController : ApiController
    {
        [HttpGet]
        [Route("ValidateEmail")]
        public bool ValidateEmail([FromUri] string email)
        {
            // not implemented yet
            return true;
        }

        [HttpPost]
        [Route("ChangePassword")]
        public bool ChangePassword(string oldPassword, string newPassword, string newPasswordConfirm)
        {
            // not implemented yet
            // return newPassword != oldPassword && newPassword == newPasswordConfirm;
            return true;
        }
    }
}
