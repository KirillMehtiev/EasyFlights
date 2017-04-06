using System.Data.Entity;
using System.Reflection;
using EasyFlights.DomainModel.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyFlights.Data.DataContexts
{
    public class EasyFlightsDataContext : IdentityDbContext<ApplicationUser>, IDataContext
    {
        public EasyFlightsDataContext() : base("DefaultConnection", false)
        {
        }

        public bool AutoDetectChangesEnabled
        {
            get { return Configuration.AutoDetectChangesEnabled; }
            set { Configuration.AutoDetectChangesEnabled = value; }
        }

        public void DetectChanges()
        {
            ChangeTracker.DetectChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(EasyFlightsDataContext)));
        }
    }
}
