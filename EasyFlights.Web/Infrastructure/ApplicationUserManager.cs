using EasyFlights.DomainModel.Entities.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;

namespace EasyFlights.Web.Infrastructure
{
    public class ApplicationUserManager : UserManager<ApplicationUser>, IApplicationUserManager
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store, IdentityFactoryOptions<ApplicationUserManager> options)
            : base(store)
        {
            // Configure validation logic for usernames
            this.UserValidator = new UserValidator<ApplicationUser>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Password Validations
            this.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            IDataProtectionProvider dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                this.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
        }
    }
}