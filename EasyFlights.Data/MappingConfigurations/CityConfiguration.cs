using System.Data.Entity.ModelConfiguration;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.MappingConfigurations
{
    public class CityConfiguration : EntityTypeConfiguration<City>
    {
        public CityConfiguration()
        {
            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Cities");
            });

            Property(city => city.Name).IsRequired();

            HasRequired(city => city.Country).WithMany(country => country.Cities);
        }
    }
}
