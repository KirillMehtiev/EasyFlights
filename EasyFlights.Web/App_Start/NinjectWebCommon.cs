using Ninject;
using Ninject.Web.Common;
using System.Reflection;
using System.Web.Http;
using EasyFlights.Web.Util;
using System;

namespace EasyFlights.Web.App_Start
{
    public static class NinjectWebCommon 
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                RegisterServices(kernel);
                return kernel;
            }
            catch(Exception e)
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Load(Assembly.GetCallingAssembly());
        }        
    }
}
