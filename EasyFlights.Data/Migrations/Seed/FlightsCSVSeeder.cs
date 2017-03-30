using System;
using System.Linq;
using EasyFlights.Data.DataContexts;
using EasyFlights.Data.Properties;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.Migrations.Seed
{
    public class FlightsCsvSeeder
    {
        private const int DepartureIndex = 1;
        private const int DepartureTimeIndex = 2;
        private const int ArrivalIndex = 3;
        private const int ArrivalTimeIndex = 4;
        private const string TimeFormat = "HH:mm";

        public void Seed(IDataContext context)
        {
            if (context.Set<Flight>().Any())
            {
                return;
            }
            string[] flightsInfo = Resources.flights.Split('\n');
            context.AutoDetectChangesEnabled = false;
            try
            {
                for (var i = 1; i < flightsInfo.Length; i++)
                {
                    string[] info = flightsInfo[i].Split(';');
                    if (info.Length < ArrivalTimeIndex + 1)
                    {
                        continue;
                    }
                    string departureAirportName = info[DepartureIndex];
                    Airport departureAirport =
                        context.Set<Airport>().FirstOrDefault(x => x.Title == departureAirportName);
                    string arrivalAirportName = info[ArrivalIndex];
                    Airport arrivalAirport =
                        context.Set<Airport>().FirstOrDefault(x => x.Title == arrivalAirportName);
                    Aircraft aircraft = context.Set<Aircraft>().FirstOrDefault();
                    if (arrivalAirport == null || departureAirport == null || aircraft == null)
                    {
                        continue;
                    }
                    DateTime departureTime = DateTime.ParseExact(info[DepartureTimeIndex], TimeFormat, null);
                    DateTime arrivalTime = DateTime.ParseExact(info[ArrivalTimeIndex].Substring(0, 5), TimeFormat, null);                   
                    for (var day = 0; day < 20; day++)
                    {
                        DateTime scheduledDeparture =
                            DateTime.Today.AddDays(day).AddHours(departureTime.Hour).AddMinutes(departureTime.Minute);
                        DateTime scheduledArrival =
                           DateTime.Today.AddDays(day).AddHours(arrivalTime.Hour).AddMinutes(arrivalTime.Minute);
                        var flight = new Flight
                        {
                            Aircraft = aircraft,
                            DepartureAirport = departureAirport,
                            DestinationAirport = arrivalAirport,
                            ScheduledDepartureTime = scheduledDeparture,
                            ScheduledArrivalTime = scheduledArrival
                        };
                        context.Set<Flight>().Add(flight);
                        flight = new Flight
                        {
                            Aircraft = aircraft,
                            DepartureAirport = arrivalAirport,
                            DestinationAirport = departureAirport,
                            ScheduledDepartureTime = scheduledDeparture.AddHours(2),
                            ScheduledArrivalTime = scheduledArrival.AddHours(2)
                        };
                        context.Set<Flight>().Add(flight);
                    }
                }
            }
            finally
            {
                context.AutoDetectChangesEnabled = true;
                context.DetectChanges();
            }
            context.SaveChanges();
        }
    }
}
