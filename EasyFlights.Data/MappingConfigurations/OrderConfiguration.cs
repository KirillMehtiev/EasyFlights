using System.Data.Entity.ModelConfiguration;
using EasyFlights.DomainModel;

namespace EasyFlights.Data.MappingConfigurations
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            this.HasMany(order => order.Tickets).WithRequired(ticket => ticket.Order);

            this.HasRequired(order => order.User).WithMany(user => user.Orders);
        }
    }
}
