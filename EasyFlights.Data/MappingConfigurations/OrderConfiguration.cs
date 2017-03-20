using System.Data.Entity.ModelConfiguration;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.MappingConfigurations
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            this.Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Orders");
            });

            this.HasMany(order => order.Tickets).WithRequired(ticket => ticket.Order);

            this.HasRequired(order => order.User).WithMany(user => user.Orders);
        }
    }
}
