using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BPS.HiltonDirect.Core.Utilities
{
    public static class CookieUtil<T> where T : class
    {
        public static void AddCookie(HttpContextBase httpContext, string key, string value)
        {
            var cookie = new HttpCookie(key);
            cookie.Value = value;
            if (!httpContext.Request.Cookies.AllKeys.Contains(key))
            {
                httpContext.Response.Cookies.Add(cookie);
            }
            else
            {
                httpContext.Response.Cookies.Set(cookie);
            }
        }

        public static void AddCookie(HttpContextBase httpContext, string key, T value)
        {
            var cookie = new HttpCookie(key);
            cookie.Value = JsonConvert.SerializeObject(value);
            if (!httpContext.Request.Cookies.AllKeys.Contains(key))
            {
                httpContext.Response.Cookies.Add(cookie);
            }
            else
            {
                httpContext.Response.Cookies.Set(cookie);
            }
        }

        public static T TryGetCookie(HttpContextBase httpContext, string key)
        {
            if (httpContext.Request.Cookies[key] != null)
                return JsonConvert.DeserializeObject<T>(httpContext.Request.Cookies[key].Value);
            return null;
        }

        public static T TryGetCookie(HttpRequest request, string key)
        {
            if (request.Cookies[key] != null)
                return JsonConvert.DeserializeObject<T>(request.Cookies[key].Value);
            return null;
        }
    }
}
