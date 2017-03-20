using System.Data.Entity.ModelConfiguration;
using EasyFlights.DomainModel;

namespace EasyFlights.Data.MappingConfigurations
{
    public class CityConfiguration : EntityTypeConfiguration<City>
    {
        public CityConfiguration()
        {
            this.Property(city => city.Name).IsRequired();

            this.HasRequired(city => city.Country).WithMany(country => country.Cities);
        }
    }
}
