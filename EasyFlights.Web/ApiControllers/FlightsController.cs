using System;
using System.Collections.Generic;
using System.Web.Http;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Web.ViewModels;

namespace EasyFlights.Web.ApiControllers
{
    [RoutePrefix("api/flights")]
    public class FlightsController : ApiController
    {

        public FlightsController()
        {
        }

        [HttpGet]
        [Route("get")]
        public List<FlightViewModel> GetFlights(int routeId)
        {
            List<Flight> flights = new List<Flight>();//this.GetFlightsByRouteId(routeId);
            var result = new List<FlightViewModel>();
            foreach (Flight flight in flights)
            {
                var element = new FlightViewModel()
                {
                    ArrivalTime = flight.ScheduledArrivalTime.ToLongTimeString(),
                    DepartureAirport = flight.DepartureAirport.Title,
                    DepartureTime = flight.ScheduledDepartureTime.ToLongTimeString(),
                    DestinationAirport = flight.DestinationAirport.Title,
                    Duration = DateTime.FromFileTimeUtc(
                        flight.ScheduledArrivalTime.ToFileTimeUtc() - flight.ScheduledDepartureTime.ToFileTimeUtc()).ToShortTimeString(),
                    Fare = flight.DefaultFare,                   
                };
                foreach (Ticket ticket in flight.Tickets)
                {
                    element.Tickets.Add(new TicketVIewModel()
                    {
                        Discount = ticket.Discount,
                        Fare = ticket.Fare,
                        Seat = ticket.Seat
                    });
                }
            }
            return result;
        }
    }
}
