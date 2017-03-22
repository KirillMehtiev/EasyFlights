using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities.Identity;
using EasyFlights.Services.Infrastracture;
using EasyFlights.Services.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyFlights.Services.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {
            UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>());
        }

        public UserManager<ApplicationUser> UserManager { get; }

        public async Task<ClaimsIdentity> Authenticate(UserDto userDto)
        {
            ClaimsIdentity claim = null;

            ApplicationUser user = await UserManager.FindAsync(userDto.Email, userDto.Password);

            if (user != null)
            {
                claim = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }

            return claim;
        }

        public async Task<IdentityResult> ChangePassword(UserDto userDto, string newPassword)
        {
            if (userDto == null)
            {
                return IdentityResult.Failed();
            }

            IdentityResult result = await UserManager.ChangePasswordAsync(userDto.Id, userDto.Password, newPassword);
            return result;
        }

        public async Task<OperationDetails> Create(UserDto userDto)
        {
            ApplicationUser user = await UserManager.FindByEmailAsync(userDto.Email);
            if (user != null)
            {
                return new OperationDetails(false, "User with such login already exists", "Email");
            }

            user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
            IdentityResult result = await this.UserManager.CreateAsync(user, userDto.Password);
            if (result.Errors.Any())
            {
                return new OperationDetails(false, result.Errors.FirstOrDefault(), string.Empty);
            }

            await UserManager.AddToRoleAsync(user.Id, userDto.Role);

            return new OperationDetails(true, "The operation was successful", string.Empty);
        }
    }
}
