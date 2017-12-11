using BPS.HiltonDirect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using Microsoft.Practices.Unity;
using System.Security;
using System.Diagnostics;
using System.Net;

namespace BPS.HiltonDirect.WebApp.Attribute
{
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger logger;
        public ExceptionHandlingAttribute(ILogger logger)
        {
            this.logger = logger;
        }

        public static ExceptionHandlingAttribute CreateInstance()
        {
            var container = UnityConfig.GetConfiguredContainer();
            return new ExceptionHandlingAttribute(container.Resolve<ILogger>());
        }

        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is SecurityException)
            {
                var message = string.Format("SecurityException caught");

                logger.Log(message, TraceEventType.Warning, LoggingCategory.API);
                logger.LogException(context.Exception, LoggingCategory.API);
            }
            else
            {
                var message = string.Format("Unhandled Exception caught");

                logger.Log(message, TraceEventType.Warning, LoggingCategory.API);
                logger.LogException(context.Exception, LoggingCategory.API);
            }
            base.OnException(context);
        }

    }
}