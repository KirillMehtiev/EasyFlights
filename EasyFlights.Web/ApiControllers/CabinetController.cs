using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using EasyFlights.DomainModel.Entities.Identity;
using EasyFlights.Web.Infrastructure;
using EasyFlights.Web.ViewModels.AccountViewModels;
using Microsoft.AspNet.Identity;
using EasyFlights.Services.Interfaces;
using EasyFlights.DomainModel.DTOs;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.Owin;

namespace EasyFlights.Web.ApiControllers
{
    [RoutePrefix("api/Cabinet")]
    public class CabinetController : ApiController
    {
        private readonly IApplicationUserManager userManager;
        private readonly IManageOrdersService manageOrderService;

        public CabinetController(IApplicationUserManager userManager, IManageOrdersService manageOrderService)
        {
            this.userManager = userManager;
            this.manageOrderService = manageOrderService;
        }

        [HttpGet]
        [Authorize]
        [Route("ValidateEmail")]
        public async Task<bool> ValidateEmailAsync([FromUri] string email)
        {
            ApplicationUser user = await userManager.FindByIdAsync(User.Identity.GetUserId());
            return user.Email == email;
        }

        [HttpPost]
        [Authorize]
        [Route("ChangePassword")]
        public async Task<bool> ChangePassword([FromBody] ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }
            ApplicationUser user = await userManager.FindByIdAsync(User.Identity.GetUserId());
            user.PasswordHash = userManager.PasswordHasher.HashPassword(model.NewPassword);
            IdentityResult result = await userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        [HttpGet]
        public async Task<List<OrderDto>> GetOrdersForUser()
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);

            var orders = await manageOrderService.GetOrdersForUser(user.Id);
            return orders;
        }
    }
}
