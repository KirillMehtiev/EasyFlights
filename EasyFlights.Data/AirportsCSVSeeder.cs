namespace EasyFlights.Data
{
    using System.IO;
    using System.Linq;
    using EasyFlights.DomainModel.Entities;
    using EasyFlights.Data.DataContexts;


    /// <summary>
    /// Seeder class for initiating airports, cities and countries tables.
    /// </summary>
    public class AirportsCsvSeeder
    {
        /// <summary>
        /// The name of initial *.CSV file.
        /// </summary>
        private const string Filename = "../../airports.csv";

        /// <summary>
        /// The method for seeding tables.
        /// </summary>
        public void Seed()
        {
            var context = new EasyFlightsDataContext();
            using (var stream = new FileStream(Filename, FileMode.OpenOrCreate))
            {
                var reader = new StreamReader(stream);
                string row;
                reader.ReadLine();
                while ((row = reader.ReadLine()) != null)
                {
                    string[] info = row.Split(';');

                    City city = context.Set<City>().FirstOrDefault(x => x.Name == info[2]);
                    if (city == null)
                    {
                        city = new City() { Name = info[2] };
                        context.Set<City>().Add(city);
                    }
                    Country country = context.Set<Country>().FirstOrDefault(x => x.Name == info[3]);
                    if (country == null)
                    {
                        country = new Country() { Name = info[3] };
                        context.Set<Country>().Add(country);
                    }
                    var airport = new Airport()
                    {
                        Title = info[1],
                        City = city,
                        AirportCodeIata = info[4],
                        AirportCodeIcao = info[5],
                        TimeZoneOffset = int.Parse(info[6])
                    };
                    context.Set<Airport>().Add(airport);
                    context.SaveChanges();
                }

                reader.Close();
            }
        }
    }
}
