using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.MappingConfigurations
{
    public class OrderConfiguration : BaseEntityConfiguration<Order>
    {
        public OrderConfiguration()
        {
            HasMany(order => order.Tickets).WithRequired(ticket => ticket.Order).WillCascadeOnDelete(false);
            HasRequired(order => order.User).WithMany(user => user.Orders);
        }
    }
}
