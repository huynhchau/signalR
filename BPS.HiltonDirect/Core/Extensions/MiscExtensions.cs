using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Core.Extensions
{
    public static class MiscExtensions
    {
        public static string DecodeHtml(this string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                s = WebUtility.HtmlDecode(s);
            }
            return s;
        }

        public static string DecodeUrl(this string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                s = WebUtility.UrlDecode(s);
            }
            return s;
        }

        public static string CorrectEmail(this string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                s = s.Replace("_", ".");
            }
            return s;
        }
    }
}
