using System.Security.Claims;
using System.Threading.Tasks;
using EasyFlights.DomainModel.Entities.Identity;
using Microsoft.AspNet.Identity;

namespace EasyFlights.Services.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUser user, string authenticationType)
        {
            ClaimsIdentity userIdentity = await this.CreateIdentityAsync(user, authenticationType);

            return userIdentity;
        }
    }
}
