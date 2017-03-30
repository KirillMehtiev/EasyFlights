using System;
using System.Linq;
using EasyFlights.DomainModel.DTOs;

namespace EasyFlights.Engines.RouteBuilding
{
    public class RouteGeneralInfoCalculator : IRouteGeneralInfoCalculator
    {
        public decimal GetTotalCost(Route route)
        {
            return route.Flights.Sum(flight => flight.DefaultFare);
        }

        public TimeSpan GetTotalTime(Route route)
        {
            double totalMinutes = route.Flights.Sum(flight =>
            {
                return (flight.ScheduledArrivalTime - flight.ScheduledDepartureTime).TotalMinutes;
            });

            return TimeSpan.FromMinutes(totalMinutes);
        }
    }
}
