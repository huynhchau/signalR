using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using BPS.HiltonDirect.Core.Unity;

namespace BPS.HiltonDirect.WebApp
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        private static readonly Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() => new BPSUnityContainer());
    }
}
