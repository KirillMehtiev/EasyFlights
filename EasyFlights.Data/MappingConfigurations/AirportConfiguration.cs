using EasyFlights.DomainModel;
using System.Data.Entity.ModelConfiguration;

namespace EasyFlights.Data.MappingConfigurations
{
    public class AirportConfiguration : EntityTypeConfiguration<Airport>
    {
        public AirportConfiguration()
        {
            this.Property(ap => ap.Title).IsRequired();
            this.Property(ap => ap.AirportCodeIata).IsRequired();
            this.Property(ap => ap.AirportCodeIcao).IsRequired();
            this.Property(ap => ap.TimeZoneOffset).IsRequired();

            // TODO: clarify what property a flight should have
            this.HasMany(ap => ap.Flights).WithRequired(flight => flight.DepartureAirport);

            this.HasRequired(ap => ap.City).WithMany(city => city.Airports);
        }
    }
}
