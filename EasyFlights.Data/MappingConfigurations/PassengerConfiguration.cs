using System.Data.Entity.ModelConfiguration;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.MappingConfigurations
{
    public class PassengerConfiguration : EntityTypeConfiguration<Passenger>
    {
        public PassengerConfiguration()
        {
            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Passengers");
            });
            Property(p => p.FirstName).IsRequired();
            Property(p => p.LastName).IsRequired();
            Property(p => p.DocumentNumber).IsRequired();
        }
    }
}
