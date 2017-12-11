using BPS.HiltonDirect.Core.Unity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPS.HiltonDirect.Web.App_Start
{
    public class UnityConfig
    {
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        private static readonly Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() => new BPSUnityContainer());
    }
}