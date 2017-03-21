using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using EasyFlights.Data.Identity;
using EasyFlights.DomainModel.Entities.Identity;
using EasyFlights.Services.Infrastracture.Account;
using EasyFlights.Services.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;

namespace EasyFlights.Services.Services
{
    public class OAuthService : IOAuthService
    {
        public OAuthService(ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            AccessTokenFormat = accessTokenFormat;
        }

        public UserManager<ApplicationUser> UserManager => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

        public IAuthenticationManager AuthenticationManager => HttpContext.Current.GetOwinContext().Authentication;

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; }

        public async Task<IdentityResult> AddExternalLogin(string externalAccessToken, string userId)
        {
            this.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            AuthenticationTicket ticket = AccessTokenFormat.Unprotect(externalAccessToken);

            if (ticket?.Identity == null || (ticket.Properties?.ExpiresUtc != null && ticket.Properties.ExpiresUtc.Value < DateTimeOffset.UtcNow))
            {
                return IdentityResult.Failed();
            }

            ExternalLoginData externalData = ExternalLoginData.FromIdentity(ticket.Identity);

            if (externalData == null)
            {
                return IdentityResult.Failed();
            }

            IdentityResult result = await UserManager.AddLoginAsync(userId, new UserLoginInfo(externalData.LoginProvider, externalData.ProviderKey));

            return result;
        }

        public async Task<bool> GetExternalLogin(ClaimsIdentity claimsIdentity, string provider)
        {
            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(claimsIdentity);

            if (externalLogin.LoginProvider != provider)
            {
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                return false;
            }

            ApplicationUser user = await UserManager.FindAsync(new UserLoginInfo(externalLogin.LoginProvider, externalLogin.ProviderKey));

            bool hasRegistered = user != null;

            if (hasRegistered)
            {
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);

                ClaimsIdentity authIdentity = await user.GenerateUserIdentityAsync(UserManager, OAuthDefaults.AuthenticationType);
                ClaimsIdentity cookieIdentity = await user.GenerateUserIdentityAsync(UserManager, CookieAuthenticationDefaults.AuthenticationType);
                AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user.UserName);
                AuthenticationManager.SignIn(properties, authIdentity, cookieIdentity);
            }
            else
            {
                IEnumerable<Claim> claims = externalLogin.GetClaims();
                var identity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
                AuthenticationManager.SignIn(identity);
            }

            return true;
        }

        public async Task<IdentityResult> RegisterExternal(string email)
        {
            ExternalLoginInfo info = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return IdentityResult.Failed();
            }

            var user = new ApplicationUser
            {
                UserName = email,
                Email = email
            };

            IdentityResult result = await UserManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                return result;
            }

            result = await UserManager.AddLoginAsync(user.Id, info.Login);

            return result;
        }
    }
}
