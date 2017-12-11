using BPS.HiltonDirect.Model;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.ExtraInformation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BPS.HiltonDirect.Services
{
    public class Logger : ILogger
    {
        private readonly LogWriter logWriter;

        public Logger(LogWriter logWriter)
        {
            this.logWriter = logWriter;
        }

        private void WriteLogMessage(Action<LogWriter> action)
        {
            try
            {
                if (logWriter.IsLoggingEnabled())
                {
                    action(logWriter);
                }
            }
            catch { }
        }

        public void Log(string message, TraceEventType severity = TraceEventType.Information, LoggingCategory category = LoggingCategory.Default)
        {
            WriteLogMessage(x =>
            {
                var log = new LogEntry
                {
                    Message = message,
                    Categories = GetCategory(category),
                    Severity = severity,
                    EventId = (int)category,
                    Priority = 1 // we don't reallly use this right now
                };

                if (x.ShouldLog(log))
                {

                    try
                    {
                        Dictionary<string, object> extra = new Dictionary<string, object>();

                        var debugInformationProvider = new DebugInformationProvider();
                        debugInformationProvider.PopulateDictionary(extra);

                        if (HttpContext.Current != null)
                        {
                            var contextInformationProvider = new ManagedSecurityContextInformationProvider();
                            contextInformationProvider.PopulateDictionary(extra);
                        }
                        log.ExtendedProperties = extra;
                    }
                    catch
                    {
                        string ds = "";
                    }
                    finally
                    {
                        x.Write(log);
                    }

                }


            });
        }

        public void LogException(Exception exception, LoggingCategory category = LoggingCategory.Default)
        {
            Log(exception.ToString(), TraceEventType.Error, category);
        }

        private static ICollection<string> GetCategory(LoggingCategory category)
        {
            switch (category)
            {
                case LoggingCategory.Default:
                    return new[] { Model.Resource.Default };
                case LoggingCategory.API:
                    return new[] { Model.Resource.API };
                case LoggingCategory.Services:
                    return new[] { Model.Resource.Services };
                case LoggingCategory.Repositories:
                    return new[] { Model.Resource.Repositories };
                default:
                    return new[] { Model.Resource.Default };
            }
        }
    }
}
