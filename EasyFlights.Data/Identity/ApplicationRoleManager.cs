using EasyFlights.Data.DataContexts;
using EasyFlights.DomainModel.Entities.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace EasyFlights.Data.Identity
{
    public class AppRoleManager : RoleManager<ApplicationRole>
    {
        public AppRoleManager(RoleStore<ApplicationRole> store) : base(store) { }

        public static AppRoleManager Create(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context)
        {
            return new AppRoleManager(new RoleStore<ApplicationRole>(context.Get<EasyFlightsDataContext>()));
        }
    }
}
