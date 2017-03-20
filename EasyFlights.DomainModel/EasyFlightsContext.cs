using System.Data.Entity;

namespace EasyFlights.DomainModel
{
    public class EasyFlightsContext : DbContext
    {
        public EasyFlightsContext() : base("EasyFlightsContext")
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
