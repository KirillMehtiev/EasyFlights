namespace EasyFlights.Data.MappingConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using EasyFlights.DomainModel.Entities.Identity;

    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            this.Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("ApplicationUsers");
            });

            this.Property(u => u.FirstName).IsRequired();
            this.Property(u => u.LastName).IsRequired();
        }
    }
}
