using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.MappingConfigurations
{
    public class AircraftConfiguration : BaseEntityConfiguration<Aircraft>
    {
        public AircraftConfiguration()
        {
            ToTable(nameof(Aircraft) + "s");
            Property(ac => ac.Model).IsRequired();
        }
    }
}
