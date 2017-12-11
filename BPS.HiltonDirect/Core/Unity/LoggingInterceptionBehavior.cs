using BPS.HiltonDirect.Model;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Core.Unity
{
    public class LoggingInterceptionBehavior : IInterceptionBehavior
    {
        private readonly ILogger logger;

        protected virtual LoggingCategory Category
        {
            get { return LoggingCategory.Default; }
        }


        public LoggingInterceptionBehavior(ILogger logger)
        {
            this.logger = logger;
        }


        public IMethodReturn Invoke(IMethodInvocation input,
          GetNextInterceptionBehaviorDelegate getNext)
        {
            var sw = new Stopwatch();
            sw.Start();

            // Invoke the next behavior in the chain.
            var result = getNext()(input, getNext);

            // After invoking the method on the original target.
            if (result.Exception != null)
            {
                sw.Stop();
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        logger.LogException(result.Exception.GetBaseException(), Category);
                    }
                    catch
                    {
                    }
                });

            }
            else
            {
                sw.Stop();
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        logger.Log(String.Format(
                          "Call: {0}{1} - {2}ms",
                          input.Target != null ? input.Target.ToString() + "." : "",
                          input.MethodBase.Name, sw.ElapsedMilliseconds), TraceEventType.Verbose, Category);
                    }
                    catch
                    {
                    }
                });
            }

            return result;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; }
        }

    }

    internal class ServicesLoggingInterceptionBehavior : LoggingInterceptionBehavior
    {
        public ServicesLoggingInterceptionBehavior(ILogger logger)
            : base(logger)
        { }

        protected override LoggingCategory Category
        {
            get { return LoggingCategory.Services; }
        }
    }

    internal class APILoggingInterceptionBehavior : LoggingInterceptionBehavior
    {
        public APILoggingInterceptionBehavior(ILogger logger)
            : base(logger)
        { }

        protected override LoggingCategory Category
        {
            get { return LoggingCategory.API; }
        }
    }

    internal class RepositoriesLoggingInterceptionBehavior : LoggingInterceptionBehavior
    {
        public RepositoriesLoggingInterceptionBehavior(ILogger logger)
            : base(logger)
        { }

        protected override LoggingCategory Category
        {
            get { return LoggingCategory.Repositories; }
        }
    }
}
