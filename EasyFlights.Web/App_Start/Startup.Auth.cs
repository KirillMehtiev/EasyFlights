using System;
using System.Security.Claims;
using System.Threading.Tasks;
using EasyFlights.Web.Identity;
using EasyFlights.Web.Infrastructure;
using EasyFlights.Web.Providers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace EasyFlights.Web
{
    public partial class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        public static FacebookAuthenticationOptions FacebookAuthOptions { get; private set; }

        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static IDataProtectionProvider DataProtectionProvider { get; private set; }

        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            DataProtectionProvider = app.GetDataProtectionProvider();

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login222"),
            });

            // Configure the application for OAuth based flow
            PublicClientId = "self";

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();

            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(10),
                AllowInsecureHttp = true
            };

            app.UseOAuthBearerTokens(OAuthOptions);
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
            app.UseFacebookAuthentication(new FacebookAuthenticationOptions
            {
                AppId = "197059630795187",
                AppSecret = "3d57cfebeca91a5335ba52a6535d2eca",
                BackchannelHttpHandler = new FacebookBackChannelHandler(),
                UserInformationEndpoint = "https://graph.facebook.com/v2.4/me?fields=id,name,email,first_name,last_name"
            });

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "597379744281-u7u378hh1g3bf2bdufnkhpf515chcdun.apps.googleusercontent.com",
                ClientSecret = "ZHGIbd45VdD0QLozbVmL2Qvk"
            });
        }
    }
}

