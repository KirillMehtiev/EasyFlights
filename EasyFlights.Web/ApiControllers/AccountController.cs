using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using EasyFlights.DomainModel.Entities.Enums;
using EasyFlights.DomainModel.Entities.Identity;
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

        public AccountController(IAuthenticationManager authenticationManager, IApplicationUserManager applicationUserManager)
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
        public IHttpActionResult IsAuthenticated()
        {
            bool result = User.Identity.IsAuthenticated;
            if (!result)
            {
                return this.BadRequest();
            }
            return this.Ok();
        }

        // POST api/Account/Login
        [Route("SignIn")]
        [HttpPost]
        public async Task<IHttpActionResult> SignIn([FromBody]LoginViewModel model)
        {
            this.authenticationManager.SignOut();
            ApplicationUser user = await this.applicationUserManager.FindAsync(model.UserEmail, model.UserPassword);
            if (user == null)
            {
                return GetErrorResult(IdentityResult.Failed());
            }

            ClaimsIdentity claim = await this.applicationUserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            this.authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);
            return this.Ok();
        }

        // POST api/Account/ChangeUser
        [Route("ChangeUser")]
        [HttpPost]
        public async Task<IHttpActionResult> ChangeUser([FromBody]ProfileViewModel model)
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

            user.DateOfBirth = DateTime.Parse(model.DateOfBirth);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Sex = (Sex)Enum.Parse(typeof(Sex), model.Sex);
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
                DateOfBirth = user.DateOfBirth.ToString(),
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Sex = user.Sex.ToString()
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

            ApplicationUser user = await this.applicationUserManager.FindAsync(new UserLoginInfo(externalLogin.LoginProvider, externalLogin.ProviderKey));

            bool hasRegistered = user != null;

            if (hasRegistered)
            {
                this.authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);

                ClaimsIdentity authIdentity = await this.applicationUserManager.CreateIdentityAsync(user, OAuthDefaults.AuthenticationType);
                ClaimsIdentity cookieIdentity = await this.applicationUserManager.CreateIdentityAsync(user, CookieAuthenticationDefaults.AuthenticationType);

                AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user.UserName);
                this.authenticationManager.SignIn(properties, authIdentity, cookieIdentity);
            }
            else
            {
                IEnumerable<Claim> claims = externalLogin.GetClaims();
                var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                this.authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, identity);
            }

            return Ok();
        }

        // POST api/Account/RegisterExternal
        [AllowAnonymous]
        [Route("RegisterExternal")]
        public async Task<IHttpActionResult> RegisterExternal(RegisterExternalBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ParsedExternalAccessToken verifiedAccessToken = await VerifyExternalAccessToken(model.Provider, model.ExternalAccessToken);
            if (verifiedAccessToken == null)
            {
                return BadRequest("Invalid Provider or External Access Token");
            }

            ApplicationUser user = await this.applicationUserManager.FindAsync(new UserLoginInfo(model.Provider, verifiedAccessToken.UserId));

            bool hasRegistered = user != null;

            if (hasRegistered)
            {
                return BadRequest("External user is already registered");
            }

            user = new ApplicationUser { UserName = model.UserName };

            IdentityResult result = await this.applicationUserManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            var info = new ExternalLoginInfo()
            {
                DefaultUserName = model.UserName,
                Login = new UserLoginInfo(model.Provider, verifiedAccessToken.UserId)
            };

            result = await this.applicationUserManager.AddLoginAsync(user.Id, info.Login);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            // generate access token response
            JObject accessTokenResponse = GenerateLocalAccessTokenResponse(model.UserName);

            return Ok(accessTokenResponse);
        }

        // POST api/Account/ChangePassword
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await this.applicationUserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);

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

        [AllowAnonymous]
        [HttpGet]
        [Route("ObtainLocalAccessToken")]
        public async Task<IHttpActionResult> ObtainLocalAccessToken(string provider, string externalAccessToken)
        {
            if (string.IsNullOrWhiteSpace(provider) || string.IsNullOrWhiteSpace(externalAccessToken))
            {
                return BadRequest("Provider or external access token is not sent");
            }

            ParsedExternalAccessToken verifiedAccessToken = await VerifyExternalAccessToken(provider, externalAccessToken);
            if (verifiedAccessToken == null)
            {
                return BadRequest("Invalid Provider or External Access Token");
            }

            IdentityUser user = await this.applicationUserManager.FindAsync(new UserLoginInfo(provider, verifiedAccessToken.UserId));

            bool hasRegistered = user != null;

            if (!hasRegistered)
            {
                return BadRequest("External user is not registered");
            }

            // generate access token response
            JObject accessTokenResponse = GenerateLocalAccessTokenResponse(user.UserName);

            return Ok(accessTokenResponse);
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

        private async Task<ParsedExternalAccessToken> VerifyExternalAccessToken(string provider, string accessToken)
        {
            ParsedExternalAccessToken parsedToken = null;

            string verifyTokenEndPoint = string.Empty;

            if (provider == "Facebook")
            {
                // You can get it from here: https://developers.facebook.com/tools/accesstoken/
                // More about debug_tokn here: http://stackoverflow.com/questions/16641083/how-does-one-get-the-app-access-token-for-debug-token-inspection-on-facebook
                var appToken = "197059630795187";
                verifyTokenEndPoint = string.Format("https://graph.facebook.com/debug_token?input_token={0}&access_token={1}", accessToken, appToken);
            }
            else
            {
                return null;
            }

            var client = new HttpClient();
            var uri = new Uri(verifyTokenEndPoint);
            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                dynamic jObj = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                parsedToken = new ParsedExternalAccessToken();

                if (provider == "Facebook")
                {
                    parsedToken.UserId = jObj["data"]["user_id"];
                    parsedToken.AppId = jObj["data"]["app_id"];

                    if (!string.Equals(Startup.FacebookAuthOptions.AppId, parsedToken.AppId, StringComparison.OrdinalIgnoreCase))
                    {
                        return null;
                    }
                }
            }

            return parsedToken;
        }

        private JObject GenerateLocalAccessTokenResponse(string userName)
        {
            TimeSpan tokenExpiration = TimeSpan.FromDays(1);

            var identity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);

            identity.AddClaim(new Claim(ClaimTypes.Name, userName));
            identity.AddClaim(new Claim("role", "user"));

            var props = new AuthenticationProperties()
            {
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.Add(tokenExpiration),
            };

            var ticket = new AuthenticationTicket(identity, props);

            string accessToken = Startup.OAuthBearerOptions.AccessTokenFormat.Protect(ticket);

            var tokenResponse = new JObject(
                                        new JProperty("userName", userName),
                                        new JProperty("access_token", accessToken),
                                        new JProperty("token_type", "bearer"),
                                        new JProperty("expires_in", tokenExpiration.TotalSeconds.ToString()),
                                        new JProperty(".issued", ticket.Properties.IssuedUtc.ToString()),
                                        new JProperty(".expires", ticket.Properties.ExpiresUtc.ToString()));

            return tokenResponse;
        }
    }
}
