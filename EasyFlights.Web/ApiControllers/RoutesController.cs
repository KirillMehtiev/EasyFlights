using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.Services.Interfaces;
using EasyFlights.Web.ViewModels;

namespace EasyFlights.Web.ApiControllers
{
    public class RoutesController : ApiController
    {
        private const string DataFormat = "D";
        private const string DurationFormat = @"dd\.hh\:mm";

        private readonly ISearchingService searchingService;

        public RoutesController(ISearchingService searchingService)
        {
            this.searchingService = searchingService;
        }

        // GET api/<controller>
        public async Task<IEnumerable<RouteViewModel>> GetAsync([FromUri] RouteSearchViewModel search)
        {
            var routes = await searchingService.FindRoutesBetweenAirportsAsync(
                search.DepartureAirportId,
                search.DestinationAirportId,
                search.NumberOfPeople,
                search.DepartureTime,
                search.ReturnTime);

            var result = routes.Select(MapToRouteViewModel);

            return result;
        }

        private RouteViewModel MapToRouteViewModel(RouteDto route)
        {
            var routeViewModel = new RouteViewModel();
            var firstFlight = route.Flights.FirstOrDefault();
            var lastFlight = route.Flights.LastOrDefault();

            routeViewModel.TotalCoast = route.TotalCost;
            routeViewModel.TotalTime = route.TotalTime.ToString(DurationFormat);
            routeViewModel.Flights = route.Flights.Select(MapToFlightViewModel);

            if (firstFlight != null)
            {
                routeViewModel.DeparturePlace = firstFlight.DepartureAirportTitle;
                routeViewModel.DepartureTime = firstFlight.ScheduledDepartureTime.ToString(DataFormat);
            }
            if (lastFlight != null)
            {
                routeViewModel.ArrivalTime = lastFlight.DestinationAirportTitle;
                routeViewModel.DestinationPlace = lastFlight.DestinationAirportTitle;
            }

            return routeViewModel;
        }

        private FlightViewModel MapToFlightViewModel(FlightDto flight)
        {
            return new FlightViewModel
            {
                DepartureAirport = flight.DepartureAirportTitle,
                DestinationAirport = flight.DestinationAirportTitle,
                ArrivalTime = flight.ScheduledArrivalTime.ToString(DataFormat),
                DepartureTime = flight.ScheduledDepartureTime.ToString(DataFormat),
                Duration = flight.Duration.ToString(DurationFormat),
                Fare = flight.DefaultFare
            };
        }
    }

}