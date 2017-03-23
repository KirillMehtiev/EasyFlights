using System;
using System.Collections.Generic;
using EasyFlights.Data.Repositories.Flights;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Engines
{
    /// <summary>
    /// Concrete route builder implementation
    /// </summary>
    public class RouteBuilder : IRouteBuilder
    {
        private readonly IFlightsRepository flightsRepository;

        public RouteBuilder(IFlightsRepository flightsRepository)
        {
            this.flightsRepository = flightsRepository;
        }

        public IEnumerable<Flight> Build(
            Airport departure,
            Airport arrival,
            DateTime departureDate,
            DateTime? returnDate,
            int numberOfPeople = 1)
        {
            throw new NotImplementedException("Not implemented build");
        }
    }
}
