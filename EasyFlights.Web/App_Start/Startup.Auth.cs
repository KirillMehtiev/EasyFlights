using System;
using System.Security.Claims;
using System.Threading.Tasks;
using EasyFlights.Data.DataContexts;
using EasyFlights.DomainModel.Entities.Identity;
using EasyFlights.Web.Infrastracture;
using EasyFlights.Web.Providers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace EasyFlights.Web
{
    public partial class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        public static FacebookAuthenticationOptions facebookAuthOptions { get; private set; }

        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(EasyFlightsDataContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login222"),
            });

            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            //OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
            // Configure the application for OAuth based flow
            //PublicClientId = "self";

            //OAuthOptions = new OAuthAuthorizationServerOptions
            //{
            //    TokenEndpointPath = new PathString("/Token"),
            //    Provider = new ApplicationOAuthProvider(PublicClientId),
            //    AccessTokenExpireTimeSpan = TimeSpan.FromDays(10),
            //    AllowInsecureHttp = true
            //};

            //app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            //facebookAuthOptions = new FacebookAuthenticationOptions()
            //{
            //    AppId = "197059630795187",
            //    AppSecret = "3d57cfebeca91a5335ba52a6535d2eca",
            //    Provider = new FacebookAuthProvider()
            //};
            //app.UseFacebookAuthentication(facebookAuthOptions);

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "597379744281-compute@developer.gserviceaccount.com",
            //    ClientSecret = "159440aa012b69e2b96c2c201ae28ede161d2b85"
            //});
        }
    }
}
