using System.Data.Entity.ModelConfiguration;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.MappingConfigurations
{
    public class AirportConfiguration : EntityTypeConfiguration<Airport>
    {
        public AirportConfiguration()
        {
            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Airports");
            });

            Property(ap => ap.Title).IsRequired();
            Property(ap => ap.AirportCodeIata).IsRequired();
            Property(ap => ap.AirportCodeIcao).IsRequired();
            Property(ap => ap.TimeZoneOffset).IsRequired();

            // TODO: clarify what property a flight should have
            HasMany(ap => ap.Flights).WithRequired(flight => flight.DepartureAirport);

            HasRequired(ap => ap.City).WithMany(city => city.Airports);
        }
    }
}
