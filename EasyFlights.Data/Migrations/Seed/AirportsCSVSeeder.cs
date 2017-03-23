using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EasyFlights.Data.DataContexts;
using EasyFlights.Data.Properties;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.Migrations.Seed
{
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
            string[] airportsInfo = Resources.airports.Split('\n');
            for (var i = 1; i < airportsInfo.Length; i++)
            {
                string[] info = airportsInfo[i].Split(';');
                string countryName = info[CountryNameIndex];
                Country country = context.Set<Country>().Local.FirstOrDefault(x => x.Name == countryName) ?? context.Set<Country>().FirstOrDefault(x => x.Name == countryName);
                if (country == null)
                {
                    country = new Country() { Name = countryName };
                    context.Set<Country>().Add(country);
                }
                string cityName = info[CityNameIndex];
                City city = context.Set<City>().Local.FirstOrDefault(x => x.Name == cityName) ?? context.Set<City>().FirstOrDefault(x => x.Name == cityName);
                if (city == null)
                {
                    city = new City() { Name = cityName, Country = country };
                    context.Set<City>().Add(city);
                }
                var airport = new Airport
                {
                    Title = info[AirportTitleIndex],
                    City = city,
                    AirportCodeIata = info[AirportIataIndex],
                    AirportCodeIcao = info[AirportIcaoIndex],
                    TimeZoneOffset = double.Parse(info[AirportTimeZoneOffsetIndex], CultureInfo.InvariantCulture)
                };
                context.Set<Airport>().Add(airport);
            }
            context.SaveChanges();
        }
    }
}
