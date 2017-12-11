using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace BPS.HiltonDirect.Core.Unity
{
    public sealed class UnityResolver : IDependencyResolver
    {
        private IUnityContainer container;

        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            return new UnityScope(this.container);
        }

        public void Dispose()
        {
            this.container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this.container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        private sealed class UnityScope : IDependencyScope
        {
            private IUnityContainer container;

            public UnityScope(IUnityContainer parentContainer)
            {
                this.container = parentContainer.CreateChildContainer();
            }

            public object GetService(Type serviceType)
            {
                return this.container.Resolve(serviceType);
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return this.container.ResolveAll(serviceType);
            }

            public void Dispose()
            {
                this.container.Dispose();
            }
        }
    }
}
