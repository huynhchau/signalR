using System.Web.Http;
using Microsoft.Practices.Unity.WebApi;
using BPS.HiltonDirect.Core.Context;
using Microsoft.Practices.Unity;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BPS.HiltonDirect.Web.App_Start.UnityWebApiActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(BPS.HiltonDirect.Web.App_Start.UnityWebApiActivator), "Shutdown")]

namespace BPS.HiltonDirect.Web.App_Start
{
    /// <summary>Provides the bootstrapping for integrating Unity with WebApi when it is hosted in ASP.NET</summary>
    public static class UnityWebApiActivator
    {
        /// <summary>Integrates Unity when the application starts.</summary>
        public static void Start() 
        {
            var container = UnityConfig.GetConfiguredContainer();
            container.RegisterType<ICallContext, CallContext>(new HierarchicalLifetimeManager());

            var resolver = new UnityHierarchicalDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        /// <summary>Disposes the Unity container when the application is shut down.</summary>
        public static void Shutdown()
        {
            var container = UnityConfig.GetConfiguredContainer();
            container.Dispose();
        }
    }
}
