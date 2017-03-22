using System.Data.Entity.ModelConfiguration;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.MappingConfigurations
{
    public class TicketConfiguration : EntityTypeConfiguration<Ticket>
    {
        public TicketConfiguration()
        {
            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Tickets");
            });
            HasRequired(ticket => ticket.Passenger);
            HasRequired(ticket => ticket.Flight);
            HasRequired(ticket => ticket.Order).WithMany(order => order.Tickets);
        }
    }
}
