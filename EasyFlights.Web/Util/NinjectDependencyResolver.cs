using System.Web.Http.Dependencies;
using Ninject;

namespace EasyFlights.Web.Util
{
    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam) : base(kernelParam)
        {
            this.kernel = kernelParam;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(this.kernel);
        }
    }
}