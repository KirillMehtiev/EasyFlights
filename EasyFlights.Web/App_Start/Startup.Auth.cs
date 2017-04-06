using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using EasyFlights.Web.Infrastructure;
using EasyFlights.Web.Providers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
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
                BackchannelHttpHandler = new FacebookBackChannelHandler()
            });

            //FacebookAuthOptions = new FacebookAuthenticationOptions()
            //{
            //    AppId = "197059630795187",
            //    AppSecret = "3d57cfebeca91a5335ba52a6535d2eca",
            //    Provider = new FacebookAuthenticationProvider()
            //    {
            //        OnAuthenticated = async context =>
            //        {
            //            context.Identity.AddClaim(new System.Security.Claims.Claim("FacebookAccessToken",context.AccessToken));               
            //            context.Identity.AddClaim(new System.Security.Claims.Claim("urn:facebook:name", context.Name));
            //            context.Identity.AddClaim(new System.Security.Claims.Claim("urn:facebook:email", context.Email));
            //        }
            //    }
            //};

            //app.UseFacebookAuthentication(FacebookAuthOptions);
        }
    }

    public class FacebookBackChannelHandler : HttpClientHandler
    {
        protected override async System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var result = await base.SendAsync(request, cancellationToken);
            if (!request.RequestUri.AbsolutePath.Contains("access_token"))
                return result;

            // For the access token we need to now deal with the fact that the response is now in JSON format, not form values. Owin looks for form values.
            var content = await result.Content.ReadAsStringAsync();
            var facebookOauthResponse = JsonConvert.DeserializeObject<FacebookOauthResponse>(content);

            var outgoingQueryString = HttpUtility.ParseQueryString(string.Empty);
            outgoingQueryString.Add(nameof(facebookOauthResponse.access_token), facebookOauthResponse.access_token);
            outgoingQueryString.Add(nameof(facebookOauthResponse.expires_in), facebookOauthResponse.expires_in + string.Empty);
            outgoingQueryString.Add(nameof(facebookOauthResponse.token_type), facebookOauthResponse.token_type);
            var postdata = outgoingQueryString.ToString();

            var modifiedResult = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(postdata)
            };

            return modifiedResult;
        }
    }

    public class FacebookOauthResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }


}

