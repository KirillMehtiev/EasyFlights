using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.MappingConfigurations
{
    public class TicketConfiguration : BaseEntityConfiguration<Ticket>
    {
        public TicketConfiguration()
        {
            HasRequired(ticket => ticket.Passenger).WithMany().WillCascadeOnDelete(true);
            HasRequired(ticket => ticket.Flight);
            HasRequired(ticket => ticket.Order).WithMany(order => order.Tickets).WillCascadeOnDelete(true);
        }
    }
}
