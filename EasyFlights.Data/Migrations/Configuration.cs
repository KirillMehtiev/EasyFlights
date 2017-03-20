namespace EasyFlights.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EasyFlights.Data.DataContexts.EasyFlightsDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EasyFlights.Data.DataContexts.EasyFlightsDataContext context)
        {
        }
    }
}
