using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Data.Repositories.Base;
using EasyFlights.Data.DataContexts;
using System.Data.Entity;
using EasyFlights.DomainModel.Entities.Identity;
using System.Data.Entity.Infrastructure;

namespace EasyFlights.Data.Repositories.Orders
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly IDbSet<Order> orderDataSet;

        public OrderRepository(IDataContext dataContext) : base(dataContext)
        {
            this.orderDataSet = dataContext.Set<Order>();
        }

        public Task<List<Order>> GetOrdersByUserId(string userId)
        {
            return orderDataSet.Where(x => x.User.Id.Equals(userId)).ToListAsync();
        }

        public void AddOrder(ApplicationUser user, Order order)
        {

            Add(order);
            SaveChanges();
        }
    }
}
