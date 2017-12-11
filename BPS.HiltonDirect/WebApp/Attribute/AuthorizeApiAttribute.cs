using BPS.HiltonDirect.Core;
using BPSAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using BPS.HiltonDirect.Model;
using BPS.HiltonDirect.Core.Extensions;
using BPS.HiltonDirect.Core.Utilities;

namespace BPS.HiltonDirect.WebApp.Attribute
{
    public class AuthorizeApiAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            Model.SessionUser sessionUser = null;
            SetResponeHeader(httpContext);
#if DEV
            sessionUser = new SessionUser {
                UserId = "1",
                UserEmail = "jcate"
            };
#endif

#if PROD
            sessionUser = SSOAuthenticate(httpContext);
            
#endif

#if UAT
            sessionUser = UATAuthenticate(httpContext);
#endif
            SetCookie(httpContext, sessionUser);
            return !string.IsNullOrEmpty(sessionUser.UserEmail);
        }

        private Model.SessionUser SSOAuthenticate(HttpContextBase httpContext)
        {
            if (httpContext.Session[Core.Constants.Session.LoggedIn] == null)
            {
                FormsAuthentication.RedirectToLoginPage(httpContext.Request.Url.ToString());
            }

            var loggedUser = httpContext.Session[Core.Constants.Session.LoggedUser] as LoginDetailDto;
            Model.SessionUser user = new Model.SessionUser();
            if (loggedUser != null)
            {
                user.UserEmail = loggedUser.Email;
                user.UserName = loggedUser.FullName;
                user.UserId = loggedUser.OnQId;
                user.UserType = loggedUser.OnQUserType;
                user.UserHotels = loggedUser.OnQUserHotels;
            }
            return user;
        }

        private SessionUser UATAuthenticate(HttpContextBase httpContext)
        {
            var sId = httpContext.Request[Core.Constants.Session.SessionID] ?? string.Empty;
            if (string.IsNullOrEmpty(sId))
            {
                var url = ConfigUtil.GetConfigValue(Core.Constants.AppSettingKeys.Login_URL);
                httpContext.Response.Redirect($"{url}{httpContext.Request.Url.OriginalString}");
            }

            var email = CookieUtil<string>.TryGetCookie(httpContext, Core.Constants.Session.sesUserEmail).DecodeUrl();
            var user = CookieUtil<Model.SessionUser>.TryGetCookie(httpContext, email);
            if (user == null)
            {
                user = new SessionUser();
                user.UserEmail = CookieUtil<string>.TryGetCookie(httpContext, Core.Constants.Session.sesUserEmail).DecodeUrl();
                user.UserId = CookieUtil<string>.TryGetCookie(httpContext, Core.Constants.Session.sesUserID);
                user.UserType = CookieUtil<string>.TryGetCookie(httpContext, Core.Constants.Session.sesOnQUserType);
                user.UserName = CookieUtil<string>.TryGetCookie(httpContext, Core.Constants.Session.sesUserName);
                user.UserHotels = CookieUtil<string>.TryGetCookie(httpContext, Core.Constants.Session.sesOnQUserHotels);
            }

            return user;
        }

        private void SetCookie(HttpContextBase httpContext, SessionUser sessionUser)
        {
            if(sessionUser == null)
            {
                sessionUser = new SessionUser();
            }

            if (string.IsNullOrEmpty(sessionUser.UserEmail))
            {
                try
                {
                    CheckUserFromPortal(httpContext, ref sessionUser);
                }
                catch (Exception ex)
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
            }

            if (!string.IsNullOrEmpty(sessionUser.UserEmail))
            {
                CookieUtil<Model.SessionUser>.AddCookie(httpContext, Core.Constants.Session.sesUserEmail, sessionUser);
            }
        }

        private com.hilton.onqinsiderservices.clsPortalSecurityService GetExternalService()
        {
            var securityService = new com.hilton.onqinsiderservices.clsPortalSecurityService();
            var objCred = new System.Net.NetworkCredential(
                ConfigUtil.GetConfigValue(Core.Constants.AppSettingKeys.SSO_UserName),
                ConfigUtil.GetConfigValue(Core.Constants.AppSettingKeys.SSO_Password),
                ConfigUtil.GetConfigValue(Core.Constants.AppSettingKeys.SSO_Domain));

            securityService.Credentials = objCred;
            return securityService;
        }

        private void CheckUserFromPortal(HttpContextBase httpContext, ref SessionUser sessionUser)
        {
            string sessionId = string.Empty;
            var service = GetExternalService();
            sessionId = httpContext.Request.Cookies[Core.Constants.Session.SessionID].Value.ToString().DecodeUrl();
            try
            {
                sessionUser.UserName = service.SessionGetValue(sessionId, Core.Constants.Session.UserDesc);
                sessionUser.UserId = service.SessionGetValue(sessionId, Core.Constants.Session.UserId);
                sessionUser.UserEmail = service.SessionGetValue(sessionId, Core.Constants.Session.EmailAddress);
            }
            catch (Exception ex)
            {
                httpContext.Response.Cookies[Core.Constants.Session.SessionID].Expires = DateTime.Now.AddDays(-1);
            }
        }

        private void SetResponeHeader(HttpContextBase httpContext)
        {
            httpContext.Response.Expires = 0;
            httpContext.Response.ExpiresAbsolute = DateTime.Now;
            httpContext.Response.AddHeader("pragma", "no-cache");
            httpContext.Response.AddHeader("cache-control", "private");
            httpContext.Response.CacheControl = "no-cache";
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Error",
                                action = "Unauthorised"
                            })
                        );
        }
    }
}