namespace EasyFlights.Web.NinjectModules
{
    using Data.DataContexts;
    using Ninject.Modules;
    using Ninject.Web.Common;

    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            // Data contexts
            this.Bind<IDataContext>().To<EasyFlightsDataContext>().InRequestScope();

            // Repositories
        }
    }
}