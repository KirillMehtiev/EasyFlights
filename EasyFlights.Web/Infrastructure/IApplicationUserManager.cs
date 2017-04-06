using System;
using System.Security.Claims;
using System.Threading.Tasks;
using EasyFlights.DomainModel.Entities.Identity;
using Microsoft.AspNet.Identity;

namespace EasyFlights.Web.Infrastructure
{
    public interface IApplicationUserManager : IDisposable
    {
        IPasswordHasher PasswordHasher { get; set; }

        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);

        Task<IdentityResult> CreateAsync(ApplicationUser user);

        Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo userLoginInfo);

        Task<IdentityResult> ChangePasswordAsync(string userId, string oldPassword, string newPassword);       

        Task<ApplicationUser> FindAsync(string userName, string password);

        Task<ApplicationUser> FindAsync(UserLoginInfo userLoginInfo);

        Task<ApplicationUser> FindByIdAsync(string userId);

        Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser user, string authenticationType);

        Task<ApplicationUser> FindByEmailAsync(string email);

        Task<IdentityResult> UpdateAsync(ApplicationUser user);
    }
}
