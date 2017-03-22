using System.Data.Entity.ModelConfiguration;
using EasyFlights.DomainModel.Entities.Identity;

namespace EasyFlights.Data.MappingConfigurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("ApplicationUsers");
            });

            Property(u => u.FirstName).IsRequired();
            Property(u => u.LastName).IsRequired();
        }
    }
}
