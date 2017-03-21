namespace EasyFlights.Data.MappingConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using EasyFlights.DomainModel.Entities;

    public class AircraftConfiguration : EntityTypeConfiguration<Aircraft>
    {
        public AircraftConfiguration()
        {
            this.Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Aircrafts");
            });

            this.Property(ac => ac.Model).IsRequired();

            // one to one
            this.HasOptional(ac => ac.Flight).WithRequired(flight => flight.Aircraft);
        }
    }
}
