using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;
using EasyFlights.DomainModel.Entities.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyFlights.Services.Interfaces
{
    public interface IManageOrdersService
    {
        Task<List<OrderDto>> GetOrdersForUser(string userId);
        void AddOrder(ApplicationUser user, Order order);

    }
}
