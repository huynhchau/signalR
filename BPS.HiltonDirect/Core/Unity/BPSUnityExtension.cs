using BPS.HiltonDirect.Core.Utilities;
using BPS.HiltonDirect.Model;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Core.Unity
{
    public class BPSUnityExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.AddNewExtension<Interception>();

            ConfigureLogging();
            AddLoggingInterception();
        }

        private void ConfigureLogging()
        {
            IConfigurationSource configurationSource = ConfigurationSourceFactory.Create();
            var factory = new LogWriterFactory(configurationSource);
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(), false);

            Container.RegisterInstance<LogWriter>(factory.Create());
        }

        private void AddLoggingInterception()
        {
            var types = AppDomainAssemblyTypeScanner.InterfacesWithAttribute<LoggingInterceptionAttribute>();
            foreach (var type in types)
            {
                var attribute = type.GetCustomAttributes(typeof(LoggingInterceptionAttribute), true)
                    .OfType<LoggingInterceptionAttribute>()
                    .Single();

                switch (attribute.Category)
                {
                    case LoggingCategory.Default:
                        Container.RegisterType(type,
                            new Interceptor<InterfaceInterceptor>(),
                            new InterceptionBehavior<LoggingInterceptionBehavior>());
                        break;
                    case LoggingCategory.API:
                        Container.RegisterType(type,
                            new Interceptor<InterfaceInterceptor>(),
                            new InterceptionBehavior<APILoggingInterceptionBehavior>());
                        break;
                    case LoggingCategory.Services:
                        Container.RegisterType(type,
                            new Interceptor<InterfaceInterceptor>(),
                            new InterceptionBehavior<ServicesLoggingInterceptionBehavior>());
                        break;
                    case LoggingCategory.Repositories:
                        Container.RegisterType(type,
                            new Interceptor<InterfaceInterceptor>(),
                            new InterceptionBehavior<RepositoriesLoggingInterceptionBehavior>());
                        break;
                }
            }
        }
    }
}
