using System.Data.Entity.Migrations;
using EasyFlights.Data.Migrations.Seed;

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
            var airportsSeeder = new AirportsCsvSeeder();
            var aircraftsSeeder = new AircraftsCsvSeeder();
            var flightsSeeder = new FlightsCsvSeeder();
            airportsSeeder.Seed(context);
            aircraftsSeeder.Seed(context);
            flightsSeeder.Seed(context);
        }
    }
}
