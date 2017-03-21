using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using EasyFlights.Data.Identity;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities.Identity;
using EasyFlights.Services.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace EasyFlights.Services.Services
{
    public class UserService : IUserService
    {
        public UserManager<ApplicationUser> UserManager => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

        public IAuthenticationManager AuthenticationManager => HttpContext.Current.GetOwinContext().Authentication;

        public async Task<ApplicationUser> Login(string username, string password)
        {
            ApplicationUser user = await UserManager.FindAsync(username, password);
            if (user == null)
            {
                return null;
            }

            ClaimsIdentity claim = await this.UserManager.CreateIdentityAsync(user,  DefaultAuthenticationTypes.ApplicationCookie);
            this.AuthenticationManager.SignOut();
            this.AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);
            return user;
        }

        public void Logout()
        {
           AuthenticationManager.SignOut();
        }

        public async Task<bool> Register(UserDto model)
        {
            var user = new ApplicationUser
            {
                Email = model.Email, FirstName = model.Name, LastName = model.Surname
            };

           IdentityResult result = await UserManager.CreateAsync(user);
           return result.Succeeded;
        }

        public async Task<bool> ChangePassword(UserDto user, string newPassword)
        {
            if (user == null)
            {
                return false;
            }

            IdentityResult result = await UserManager.ChangePasswordAsync(user.Id, user.Password, newPassword);
            return result.Succeeded;
        }
    }
}
