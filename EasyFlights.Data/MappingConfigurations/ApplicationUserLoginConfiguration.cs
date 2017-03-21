namespace EasyFlights.Data.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public ApplicationUserLoginConfiguration()
        {
            HasKey<string>(l => l.UserId);
        }
    }
}
