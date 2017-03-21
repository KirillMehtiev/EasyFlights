using System.Data.Entity.ModelConfiguration;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.MappingConfigurations
{
    public class PassengerConfiguration : EntityTypeConfiguration<Passenger>
    {
        public PassengerConfiguration()
        {
            this.Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Passengers");
            });

            this.Property(p => p.FirstName).IsRequired();
            this.Property(p => p.LastName).IsRequired();
            this.Property(p => p.DocumentNumber).IsRequired();
        }
    }
}
