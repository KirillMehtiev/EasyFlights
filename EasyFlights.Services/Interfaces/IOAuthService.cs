using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace EasyFlights.Services.Interfaces
{
    public interface IOAuthService
    {
        Task<IdentityResult> AddExternalLogin(string externalAccessToken, string userId);

        Task<bool> GetExternalLogin(ClaimsIdentity claimsIdentity, string provider);

        Task<IdentityResult> RegisterExternal(string email);
    }
}
