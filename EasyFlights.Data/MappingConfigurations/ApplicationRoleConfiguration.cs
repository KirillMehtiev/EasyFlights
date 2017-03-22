using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyFlights.Data.MappingConfigurations
{
    public class ApplicationRoleConfiguration : EntityTypeConfiguration<IdentityRole>
    {
        public ApplicationRoleConfiguration()
        {
            HasKey(r => r.Id);
        }
    }
}
