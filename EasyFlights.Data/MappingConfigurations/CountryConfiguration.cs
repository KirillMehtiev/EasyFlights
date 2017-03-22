using System.Data.Entity.ModelConfiguration;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.MappingConfigurations
{
    public class CountryConfiguration : EntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Countries");
            });

            Property(country => country.Name).IsRequired();
        }
    }
}
