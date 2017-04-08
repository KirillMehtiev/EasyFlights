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

        void AddOrder(Order order);

        Task DeleteOrder(int orderId, string userId);

        Task<OrderDto> GetOrderByIdForUserAsync(int userId, string orderId);
    }
}
