using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Model
{
    public interface ILogger
    {
        void Log(string message, TraceEventType severity = TraceEventType.Information, LoggingCategory category = LoggingCategory.Default);

        void LogException(Exception exception, LoggingCategory category = LoggingCategory.Default);
    }
}
