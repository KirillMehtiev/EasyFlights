using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Ninject.Activation;
using Ninject.Parameters;
using Ninject.Syntax;

namespace EasyFlights.WebApi.Utils
{
    public class NinjectDependencyScope : IDependencyScope
    {
        private readonly IResolutionRoot resolutionRoot;

        public NinjectDependencyScope(IResolutionRoot kernel)
        {
            this.resolutionRoot = kernel;
        }

        public object GetService(Type serviceType)
        {
            IRequest request = this.resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return this.resolutionRoot.Resolve(request).SingleOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            IRequest request = this.resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return this.resolutionRoot.Resolve(request).ToList();
        }

        public void Dispose()
        {
        }
    }
}