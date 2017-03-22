using System.Security.Claims;
using System.Threading.Tasks;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.Services.Infrastracture;
using Microsoft.AspNet.Identity;

namespace EasyFlights.Services.Interfaces
{
    public interface IUserService
    {
        Task<ClaimsIdentity> Authenticate(UserDto userDto);

        Task<IdentityResult> ChangePassword(UserDto userDto, string newPassword);

        Task<OperationDetails> Create(UserDto userDto);
    }
}
