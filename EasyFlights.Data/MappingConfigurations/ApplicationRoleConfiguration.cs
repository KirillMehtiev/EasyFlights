using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyFlights.Data.Configurations
{
    public class ApplicationRoleConfiguration : EntityTypeConfiguration<IdentityRole>
    {
        public ApplicationRoleConfiguration()
        {
            HasKey<string>(r => r.Id);
        }
    }
}
