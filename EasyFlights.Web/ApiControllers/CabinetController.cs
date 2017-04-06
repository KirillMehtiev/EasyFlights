using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using EasyFlights.DomainModel.Entities.Identity;
using EasyFlights.Web.Infrastracture;
using EasyFlights.Web.ViewModels.AccountViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace EasyFlights.Web.ApiControllers
{
    [RoutePrefix("api/Cabinet")]
    public class CabinetController : ApiController
    {
        private ApplicationUserManager userManager;

        public ApplicationUserManager UserManager => userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();


        [HttpGet]
        [Authorize]
        [Route("ValidateEmail")]
        public async Task<bool> ValidateEmailAsync([FromUri] string email)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            return user.Email == email;
        }

        [HttpPost]
        [Authorize]
        [Route("ChangePassword")]
        public bool ChangePassword([FromBody] ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }
            ApplicationUser user = UserManager.FindById(User.Identity.GetUserId());
            user.PasswordHash = UserManager.PasswordHasher.HashPassword(model.NewPassword);
            IdentityResult result = UserManager.Update(user);
            if (!result.Succeeded)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
