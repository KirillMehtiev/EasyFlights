using System.Web.Helpers;
using System.Web.Http;
using EasyFlights.Web.ViewModels.AccountViewModels;

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
        public bool ChangePassword([FromBody] ChangePasswordViewModel model)
        {
            // not implemented yet
            return model.NewPassword != model.OldPassword && model.NewPassword == model.NewPasswordConfirm;
        }
    }
}
