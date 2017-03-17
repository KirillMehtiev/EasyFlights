using EasyFlights.DomainModel;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Reflection;

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
        }
    }
}
