namespace EasyFlights.Data.MappingConfigurations
{
    using EasyFlights.DomainModel.Entities;
    using System.Data.Entity.ModelConfiguration;

    public class AirportConfiguration : EntityTypeConfiguration<Airport>
    {
        public AirportConfiguration()
        {
            this.Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Airports");
            });

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
