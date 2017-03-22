using System.Data.Entity;
using System.Reflection;
using EasyFlights.DomainModel.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyFlights.Data.DataContexts
{
    public class EasyFlightsDataContext : IdentityDbContext<ApplicationUser>, IDataContext
    {
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
        }
    }
}
