using System.Data.Entity.ModelConfiguration;
using EasyFlights.DomainModel;

namespace EasyFlights.Data.MappingConfigurations
{
    public class AircraftConfiguration : EntityTypeConfiguration<Aircraft>
    {
        public AircraftConfiguration()
        {
            this.Property(ac => ac.Model).IsRequired();

            // one to one
            this.HasOptional(ac => ac.Flight).WithRequired(flight => flight.Aircraft);
        }
    }
}
