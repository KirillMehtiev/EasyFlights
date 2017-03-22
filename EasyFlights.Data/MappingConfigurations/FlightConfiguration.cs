using System.Data.Entity.ModelConfiguration;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.MappingConfigurations
{
    public class FlightConfiguration : EntityTypeConfiguration<Flight>
    {
        public FlightConfiguration()
        {
            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Flights");
            });

            HasRequired(flight => flight.DepartureAirport).WithMany(ap => ap.Flights);

            HasRequired(flight => flight.DestinationAirport);

            HasMany(flight => flight.Tickets).WithRequired(ticket => ticket.Flight);
        }
    }
}
