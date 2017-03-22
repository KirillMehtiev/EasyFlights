using System.Data.Entity.Migrations;

namespace EasyFlights.Data.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<DataContexts.EasyFlightsDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContexts.EasyFlightsDataContext context)
        {
            var seeder = new Seed.AirportsCsvSeeder();
            seeder.Seed(context);
        }
    }
}
