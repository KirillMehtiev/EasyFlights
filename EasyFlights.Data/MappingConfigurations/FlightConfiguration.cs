namespace EasyFlights.Data.MappingConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using EasyFlights.DomainModel.Entities;

    public class FlightConfiguration : EntityTypeConfiguration<Flight>
    {
        public FlightConfiguration()
        {
            this.Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Flights");
            });

            this.HasRequired(flight => flight.DepartureAirport).WithMany(ap => ap.Flights);

            this.HasRequired(flight => flight.DestinationAirport);

            this.HasMany(flight => flight.Tickets).WithRequired(ticket => ticket.Flight);
        }
    }
}
