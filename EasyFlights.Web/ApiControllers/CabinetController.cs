using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities.Identity;
using EasyFlights.Services.Interfaces;
using EasyFlights.Web.Infrastructure;
using EasyFlights.Web.ViewModels.AccountViewModels;
using Microsoft.AspNet.Identity;

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
        [Route("GetEmail")]
        public async Task<string> ValidateEmailAsync()
        {
            ApplicationUser user = await userManager.FindByIdAsync(User.Identity.GetUserId());
            return user.Email;
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
            if (model.NewPassword != model.NewPasswordConfirm)
            {
                return false;
            }
            ApplicationUser user = await userManager.FindByIdAsync(User.Identity.GetUserId());
            IdentityResult result = await userManager.ChangePasswordAsync(user.Id, model.OldPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }

        //[HttpGet]
        //public async Task<List<OrderDto>> GetOrdersForUser()
        //{
        //    var user = await userManager.FindByEmailAsync(User.Identity.Name);

        //    return await manageOrderService.GetOrdersForUser(user.Id);
        //}
    }
}
