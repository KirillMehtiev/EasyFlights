using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using EasyFlights.DomainModel.Entities.Enums;
using EasyFlights.DomainModel.Entities.Identity;
using EasyFlights.Web.Infrastracture;
using EasyFlights.Web.ViewModels.AccountViewModels;
using EasyFlights.Web.ViewModels.ProfileInfo;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;

namespace EasyFlights.Web.ApiControllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private ApplicationUserManager userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return this.userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }

            private set
            {
                this.userManager = value;
            }
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        private IAuthenticationManager Authentication => this.Request.GetOwinContext().Authentication;

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser()
            {
                UserName = model.UserEmail,
                Email = model.UserEmail,
                FirstName = model.UserName,
                LastName = model.UserSurname,
                PhoneNumber = model.UserPhone
            };

            IdentityResult result = await UserManager.CreateAsync(user, model.UserPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IHttpActionResult> Login([FromBody]LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser user = await UserManager.FindAsync(model.UserEmail, model.UserPassword);

            if (user == null)
            {
                return GetErrorResult(IdentityResult.Failed());
            }

            return this.Ok();
        }


        [Route("changeUser")]
        [HttpPost]
        public async Task<IHttpActionResult> ChangeUser([FromBody]ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser user = await UserManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return this.InternalServerError();
            }

            user.DateOfBirth = DateTime.Parse(model.DateOfBirth);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Sex = (Sex)Enum.Parse(typeof(Sex), model.Sex);
            user.PhoneNumber = model.ContactPhone;

            IdentityResult result = await UserManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/Account/Logout
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing && this.userManager != null)
            {
                this.userManager.Dispose();
                this.userManager = null;
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
