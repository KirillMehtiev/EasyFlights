using EasyFlights.DomainModel;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using EasyFlights.Data.Configurations;

namespace EasyFlights.Data.DataContexts
{
    public class EFDataContext : IdentityDbContext<ApplicationUser>, IDataContext
    {
        // TODO: add connection to db
        public EFDataContext() : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //configurations have been placed in MappingConfigurations folder
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(EFDataContext)));
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Configurations.Add(new UserConfiguration());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public static EFDataContext Create()
        {
            return new EFDataContext();
        }
    }
}
