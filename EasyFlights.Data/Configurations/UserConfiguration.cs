using System.Data.Entity.ModelConfiguration;
using EasyFlights.DomainModel;

namespace EasyFlights.Data.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public UserConfiguration()
        {
            ToTable("Users");
        }
    }
}
