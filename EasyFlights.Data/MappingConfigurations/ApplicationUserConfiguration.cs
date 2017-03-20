using System.Data.Entity.ModelConfiguration;
using EasyFlights.DomainModel.Entities.Identity;

namespace EasyFlights.Data.MappingConfigurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            this.Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("AplicationUsers");
            });

            this.Property(u => u.FirstName).IsRequired();
            this.Property(u => u.LastName).IsRequired();
        }
    }
}
