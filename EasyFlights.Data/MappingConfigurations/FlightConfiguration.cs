using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.MappingConfigurations
{
    public class FlightConfiguration : BaseEntityConfiguration<Flight>
    {
        public FlightConfiguration()
        {
            HasRequired(flight => flight.DepartureAirport).WithMany(ap => ap.Flights).WillCascadeOnDelete(false);

            HasRequired(flight => flight.DestinationAirport).WithMany().WillCascadeOnDelete(false);

            HasMany(flight => flight.Tickets).WithRequired(ticket => ticket.Flight).WillCascadeOnDelete(false);
        }
    }
}
