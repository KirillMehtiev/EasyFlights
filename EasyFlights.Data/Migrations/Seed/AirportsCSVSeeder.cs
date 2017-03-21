namespace EasyFlights.Data.Migrations.Seed
{
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using DataContexts;
    using DomainModel.Entities;
    using Properties;

    public class AirportsCsvSeeder
    {
        private const int AirportTitleIndex = 1;

        private const int CityNameIndex = 2;

        private const int CountryNameIndex = 3;

        private const int AirportIataIndex = 4;

        private const int AirportIcaoIndex = 5;

        private const int AirportTimeZoneOffsetIndex = 6;

        public void Seed(IDataContext context)
        {
            if (context.Set<Airport>().Any())
            {
                return;
            }
            using (var stream = new FileStream(Resources.airports, FileMode.OpenOrCreate))
            {
                using (var reader = new StreamReader(stream))
                {
                    string row;
                    reader.ReadLine();
                    while ((row = reader.ReadLine()) != null)
                    {
                        string[] info = row.Split(';');
                        Country country = context.Set<Country>().FirstOrDefault(x => x.Name == info[CountryNameIndex]);
                        if (country == null)
                        {
                            country = new Country() { Name = info[CountryNameIndex] };
                            context.Set<Country>().Add(country);
                        }
                        City city = context.Set<City>().FirstOrDefault(x => x.Name == info[CityNameIndex]);
                        if (city == null)
                        {
                            city = new City() { Name = info[CityNameIndex], Country = country };
                            context.Set<City>().Add(city);
                        }
                        var airport = new Airport()
                        {
                            Title = info[AirportTitleIndex],
                            City = city,
                            AirportCodeIata = info[AirportIataIndex],
                            AirportCodeIcao = info[AirportIcaoIndex],
                            TimeZoneOffset = int.Parse(info[AirportTimeZoneOffsetIndex], CultureInfo.InvariantCulture)
                        };
                        context.Set<Airport>().Add(airport);
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
