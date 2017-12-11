using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToShortBPSDateString(this DateTime? instance)
        {
            return instance.HasValue ? instance.Value.ToString(Constants.Misc.ShortDate) : string.Empty;
        }

        public static string ToShortBPSDateString(this DateTime instance)
        {
            return instance != DateTime.MinValue ? instance.ToString(Constants.Misc.ShortDate) : string.Empty;
        }

        public static string ToShortBPSDateString(this DateTimeOffset? instance)
        {
            return instance.HasValue ? instance.Value.LocalDateTime.ToString(Constants.Misc.ShortDate) : string.Empty;
        }

        public static string ToShortBPSDateString(this DateTimeOffset instance)
        {
            return instance.LocalDateTime != DateTime.MinValue ? instance.LocalDateTime.ToString(Constants.Misc.ShortDate) : string.Empty;
        }

        public static DateTimeOffset? TryParseToDateTimeOffset(this string instance)
        {
            DateTimeOffset val;
            if (DateTimeOffset.TryParse(instance, out val) == true)
                return val;
            return null;
        }

        public static DateTime? TryParseToDateTime(this string instance)
        {
            DateTime val;
            if (DateTime.TryParse(instance, out val) == true)
                return val;
            return null;
        }
    }
}
