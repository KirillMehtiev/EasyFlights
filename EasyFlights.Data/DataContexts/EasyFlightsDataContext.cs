using EasyFlights.DomainModel;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Reflection;
using EasyFlights.DomainModel.Identity;

namespace EasyFlights.Data.DataContexts
{
    public class EasyFlightsDataContext : IdentityDbContext<ApplicationUser>, IDataContext
    {
        // TODO: add connection to db
        public EasyFlightsDataContext() : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //configurations have been placed in MappingConfigurations folder
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(EasyFlightsDataContext)));

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public static EasyFlightsDataContext Create()
        {
            return new EasyFlightsDataContext();
        }
    }
}
