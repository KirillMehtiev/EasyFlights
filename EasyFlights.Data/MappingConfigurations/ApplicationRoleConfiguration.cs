namespace EasyFlights.Data.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationRoleConfiguration : EntityTypeConfiguration<IdentityRole>
    {
        public ApplicationRoleConfiguration()
        {
            HasKey<string>(r => r.Id);
        }
    }
}
