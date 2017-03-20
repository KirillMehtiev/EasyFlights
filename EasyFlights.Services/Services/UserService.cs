using System.Security.Claims;
using System.Threading.Tasks;
using EasyFlights.DomainModel;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;


namespace EasyFlights.Services.Services
{
    public class UserService
    {
        public async Task<ApplicationUser> Login(string username, string password)
        {
            ApplicationUser user = await UserManager.FindAsync(username, password);
            if(user != null)
            {
               ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
               AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);          
            }
            return user;
        }

        public void Logout()
        {
           AuthenticationManager.SignOut();
        }

        public async Task<bool> Register(ApplicationUser user)
        {       
           IdentityResult result = await UserManager.CreateAsync(user);
           return result.Succeeded;
        }

        private UserManager<ApplicationUser> UserManager { get; set; }

        private IAuthenticationManager AuthenticationManager { get; set; }
    }
}
