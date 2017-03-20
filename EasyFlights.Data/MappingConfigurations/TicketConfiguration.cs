using System.Data.Entity.ModelConfiguration;
using EasyFlights.DomainModel;

namespace EasyFlights.Data.MappingConfigurations
{
    public class TicketConfiguration : EntityTypeConfiguration<Ticket>
    {
        public TicketConfiguration()
        {
            this.HasRequired(ticket => ticket.Passenger);
            this.HasRequired(ticket => ticket.Flight);
            this.HasRequired(ticket => ticket.Order).WithMany(order => order.Tickets);
        }
    }
}
