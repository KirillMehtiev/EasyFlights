using System.Threading.Tasks;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities.Identity;

namespace EasyFlights.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> Login(string username, string password);

        void Logout();

        Task<bool> Register(UserDto model);

        Task<bool> ChangePassword(UserDto user, string newPassword);
    }
}
