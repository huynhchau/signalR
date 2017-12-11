using BPS.HiltonDirect.Core.Authenticate;
using BPS.HiltonDirect.Core.Context;
using BPS.HiltonDirect.Web.App_Start;
using BPS.HiltonDirect.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPS.HiltonDirect.Web
{
    public partial class Startup
    {
        private static AuthConfigurationHelper _authConfigurationHelper;

        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        private void ConfigureAuth(IAppBuilder app)
        {
            _authConfigurationHelper = new AuthConfigurationHelper();
            // Enable the application to use a cookie to store information for the signed in user
            var cookieOptions = GetCookieAuthenticationOptions();
            app.UseCookieAuthentication(cookieOptions);
            app.UseOAuthAuthorizationServer(GetOAuthOptions());
        }

        private OAuthAuthorizationServerOptions GetOAuthOptions()
        {
            return new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                AuthorizeEndpointPath = new PathString("/Account/Authorize"),
                Provider = new OAuthAuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(_authConfigurationHelper.GetAccessTokenExpireMinutes()),
                AllowInsecureHttp = _authConfigurationHelper.GetAllowInsecureHttp()
            };
        }

        private static CookieAuthenticationOptions GetCookieAuthenticationOptions()
        {
            var cookieOptions = new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                CookieSecure = CookieSecureOption.SameAsRequest,
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(2),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager)),
                }
            };
            return cookieOptions;
        }
    }
}