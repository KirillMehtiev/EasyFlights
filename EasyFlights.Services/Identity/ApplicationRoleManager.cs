using EasyFlights.DomainModel.Entities.Identity;
using Microsoft.AspNet.Identity;

namespace EasyFlights.Services.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store) : base(store)
        {
        }
    }
}
