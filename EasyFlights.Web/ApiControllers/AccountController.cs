using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using EasyFlights.DomainModel.Entities.Enums;
using EasyFlights.DomainModel.Entities.Identity;
using EasyFlights.Services.Common;
using EasyFlights.Web.Identity;
using EasyFlights.Web.Infrastructure;
using EasyFlights.Web.Results;
using EasyFlights.Web.ViewModels.AccountViewModels;
using EasyFlights.Web.ViewModels.ProfileInfo;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Linq;

namespace EasyFlights.Web.ApiControllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private readonly IAuthenticationManager authenticationManager;

        private readonly IApplicationUserManager applicationUserManager;

        public AccountController(IAuthenticationManager authenticationManager,
            IApplicationUserManager applicationUserManager)
        {
            this.authenticationManager = authenticationManager;
            this.applicationUserManager = applicationUserManager;
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [HttpPost]
        [Route("Signup")]
        public async Task<IHttpActionResult> SignUp(RegisterViewModel model)
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

            IdentityResult result = await this.applicationUserManager.CreateAsync(user, model.UserPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            ClaimsIdentity claim = await this.applicationUserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            this.authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);
            return Ok();
        }

        [Route("IsAuthenticated")]
        [HttpGet]
        public bool IsAuthenticated()
        {
            return User.Identity.IsAuthenticated;
        }

        // POST api/Account/Login
        [Route("SignIn")]
        [HttpPost]
        public async Task<IHttpActionResult> SignIn([FromBody] LoginViewModel model)
        {
            this.authenticationManager.SignOut();
            ApplicationUser user = await this.applicationUserManager.FindAsync(model.UserEmail, model.UserPassword);
            if (user == null)
            {
                return GetErrorResult(IdentityResult.Failed());
            }

            ClaimsIdentity claim = await this.applicationUserManager.CreateIdentityAsync(user,
                DefaultAuthenticationTypes.ApplicationCookie);
            this.authenticationManager.SignIn(new AuthenticationProperties {IsPersistent = true}, claim);
            return this.Ok();
        }

        // POST api/Account/ChangeUser
        [Route("ChangeUser")]
        [HttpPost]
        public async Task<IHttpActionResult> ChangeUser([FromBody] ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser user = await this.applicationUserManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return this.InternalServerError();
            }
            if (!string.IsNullOrEmpty(model.DateOfBirth))
            {
                user.DateOfBirth = DateTime.Parse(model.DateOfBirth);
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            if (!string.IsNullOrEmpty(model.Sex))
            {
                user.Sex = (Sex) Enum.Parse(typeof(Sex), model.Sex);
            }

            user.PhoneNumber = model.ContactPhone;
            IdentityResult result = await this.applicationUserManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        [Route("UserInfo")]
        public async Task<ProfileViewModel> GetUserInfo()
        {
            string email = User.Identity.Name;
            ApplicationUser user = await this.applicationUserManager.FindByEmailAsync(email);
            var profileInfo = new ProfileViewModel
            {
                ContactPhone = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth?.ToString(Format.DateFormat) ?? string.Empty,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Sex = user.Sex?.ToString("G")
            };
            return profileInfo;
        }

        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
        [AllowAnonymous]
        [EnableCors("*", "*", "*")]
        [Route("ExternalLogin", Name = "ExternalLogin")]
        public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
        {
            if (error != null)
            {
                return Redirect(Url.Content("~/") + "#error=" + Uri.EscapeDataString(error));
            }

            if (!User.Identity.IsAuthenticated)
            {
                return new ChallengeResult(provider, this);
            }

            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            if (externalLogin == null)
            {
                return InternalServerError();
            }

            if (externalLogin.LoginProvider != provider)
            {
                this.authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                return new ChallengeResult(provider, this);
            }

            ApplicationUser user = await this.applicationUserManager.FindByEmailAsync(externalLogin.Email);

            bool hasRegistered = user != null;

            if (hasRegistered)
            {
                this.authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);

                ClaimsIdentity authIdentity = await this.applicationUserManager.CreateIdentityAsync(user,
                    OAuthDefaults.AuthenticationType);
                ClaimsIdentity cookieIdentity = await this.applicationUserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);

                AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user.Email);
                this.authenticationManager.SignIn(properties, authIdentity, cookieIdentity);
            }
            else
            {
                this.authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                string[] name = externalLogin.UserName.Split(' ');
                user = new ApplicationUser
                {
                    UserName = externalLogin.Email,
                    Email = externalLogin.Email,
                    FirstName = name[0],
                    LastName = name[1]
                };

                IdentityResult result = await this.applicationUserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    ClaimsIdentity claim = await this.applicationUserManager.CreateIdentityAsync(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    this.authenticationManager.SignIn(new AuthenticationProperties {IsPersistent = true}, claim);
                }
                return this.BadRequest();
            }

            return Redirect(Url.Content("~/#userCabinet"));
        }

        // POST api/Account/ChangePassword
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await this.applicationUserManager.ChangePasswordAsync(User.Identity.GetUserId(),
                model.OldPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/Account/Logout
        [Route("SignOut")]
        public IHttpActionResult SignOut()
        {
            this.authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                applicationUserManager?.Dispose();
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