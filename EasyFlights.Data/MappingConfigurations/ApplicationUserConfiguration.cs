using System.Data.Entity.ModelConfiguration;
using EasyFlights.DomainModel.Identity;

namespace EasyFlights.Data.MappingConfigurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            this.ToTable("Users");

            this.Property(u => u.FirstName).IsRequired();
            this.Property(u => u.LastName).IsRequired();
        }
    }
}
