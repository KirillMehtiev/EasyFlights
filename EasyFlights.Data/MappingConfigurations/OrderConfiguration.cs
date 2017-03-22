using System.Data.Entity.ModelConfiguration;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.MappingConfigurations
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Orders");
            });
            HasMany(order => order.Tickets).WithRequired(ticket => ticket.Order);
            HasRequired(order => order.User).WithMany(user => user.Orders);
        }
    }
}
