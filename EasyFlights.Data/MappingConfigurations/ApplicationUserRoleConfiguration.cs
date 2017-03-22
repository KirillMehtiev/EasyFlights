using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyFlights.Data.MappingConfigurations
{
    public class ApplicationUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public ApplicationUserRoleConfiguration()
        {
            HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
