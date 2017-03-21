namespace EasyFlights.Data.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public ApplicationUserRoleConfiguration()
        {
            HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
