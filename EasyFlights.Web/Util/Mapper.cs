using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.Web.ViewModels;

namespace EasyFlights.Web.Util
{

    public class Mapper
    {
        private const string DataFormat = "D";
        private const string DurationFormat = @"dd\.hh\:mm";

        public static RouteViewModel MapToRouteViewModel(RouteDto route)
        {
            var routeViewModel = new RouteViewModel();
            var firstFlight = route.Flights.FirstOrDefault();
            var lastFlight = route.Flights.LastOrDefault();

            routeViewModel.TotalCoast = route.TotalCost;
            routeViewModel.TotalTime = route.TotalTime.ToString(DurationFormat);
            routeViewModel.Flights = route.Flights.Select(Mapper.MapToFlightViewModel);

            if (firstFlight != null)
            {
                routeViewModel.DepartureDate = firstFlight.DepartureAirportTitle;
                routeViewModel.DepartureDate = firstFlight.ScheduledDepartureTime.ToString(DataFormat);
            }
            if (lastFlight != null)
            {
                routeViewModel.ArrivalPlace = lastFlight.DestinationAirportTitle;
                routeViewModel.DestinationPlace = lastFlight.DestinationAirportTitle;
            }

            return routeViewModel;
        }

        private static FlightViewModel MapToFlightViewModel(FlightDto flight)
        {
            return new FlightViewModel
            {
                DepartureAirportTitle = flight.DepartureAirportTitle,
                DestinationAirportTitle = flight.DestinationAirportTitle,
                ScheduledArrivalTime = flight.ScheduledArrivalTime.ToString(DataFormat),
                ScheduledDepartureTime = flight.ScheduledDepartureTime.ToString(DataFormat),
                Duration = flight.Duration.ToString(DurationFormat),
                Fare = flight.DefaultFare
            };
        }
    }
}