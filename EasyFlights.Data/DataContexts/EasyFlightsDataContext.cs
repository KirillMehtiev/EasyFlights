using System.Data.Entity;
using System.Reflection;
using EasyFlights.Data.Configurations;
using EasyFlights.Data.MappingConfigurations;
using EasyFlights.DomainModel.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyFlights.Data.DataContexts
{
    public class EasyFlightsDataContext : IdentityDbContext<ApplicationUser>, IDataContext
    {
        // TODO: add connection to db
        public EasyFlightsDataContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static EasyFlightsDataContext Create()
        {
            return new EasyFlightsDataContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(EasyFlightsDataContext)));
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserLoginConfiguration());
            modelBuilder.Configurations.Add(new ApplicationRoleConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserRoleConfiguration());
        }
    }
}
