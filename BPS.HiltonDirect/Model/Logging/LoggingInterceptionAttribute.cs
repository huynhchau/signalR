using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Model
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
    public class LoggingInterceptionAttribute : Attribute
    {
        public LoggingCategory Category { get; private set; }

        public LoggingInterceptionAttribute(LoggingCategory category = LoggingCategory.Default)
        {
            Category = category;
        }
    }
}
