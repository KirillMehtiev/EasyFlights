using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyFlights.Data.Configurations
{
    public class ApplicationUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public ApplicationUserLoginConfiguration()
        {
            HasKey<string>(l => l.UserId);
        }
    }
}
