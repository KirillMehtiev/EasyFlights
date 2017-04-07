using EasyFlights.DomainModel.Entities;
using EasyFlights.DomainModel.Entities.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyFlights.Data.Repositories.Base;

namespace EasyFlights.Data.Repositories.Orders
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetOrdersByUserId(string userId);
        void AddOrder(ApplicationUser user, Order order);
    }
}
