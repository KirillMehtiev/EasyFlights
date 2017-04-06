using EasyFlights.DomainModel.Entities;
using EasyFlights.DomainModel.Entities.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyFlights.Data.Repositories.Orders
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersByUserId(string userId);
        void AddOrder(ApplicationUser user, Order order);
    }
}
