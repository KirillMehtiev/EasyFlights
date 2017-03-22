using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyFlights.Data.MappingConfigurations
{
    public class ApplicationUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public ApplicationUserLoginConfiguration()
        {
            HasKey(l => l.UserId);
        }
    }
}
