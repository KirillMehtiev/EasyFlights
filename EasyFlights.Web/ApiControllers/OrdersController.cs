using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EasyFlights.Web.ApiControllers
{
    using System.Threading.Tasks;

    using EasyFlights.DomainModel.DTOs;
    using EasyFlights.Services.Interfaces;
    using EasyFlights.Web.ViewModels.OrdersViewModel;

    using Microsoft.AspNet.Identity;

    [Authorize]
    public class OrdersController : ApiController
    {
        private readonly IManageOrdersService manageOrderService;

        public OrdersController(IManageOrdersService manageOrderService)
        {
            this.manageOrderService = manageOrderService;
        }

        // GET api/<controller>
        public async Task<IEnumerable<ShortOrderViewModel>> Get()
        {
            var userId = User.Identity.GetUserId();
            var orders = await manageOrderService.GetOrdersForUser(userId);

            return MapToShortOrderViewModels(orders);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        private IEnumerable<ShortOrderViewModel> MapToShortOrderViewModels(IEnumerable<OrderDto> orders)
        {
            return orders.Select(order => new ShortOrderViewModel
            {
                DepartureCity = order.DepartureCity,
                DestinationCity = order.DestinationCity,
                Cost = order.Cost,
                DateOfOrdering = order.DateOfOrdering,
                SetOffDate = order.SetOffDate,
                Duration = order.Duration
            });
        }

    }
}