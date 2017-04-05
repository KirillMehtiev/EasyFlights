using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.Data.Repositories.Flights;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.Services.Interfaces;

namespace EasyFlights.Services.Services.Flight
{
    public class FlightService : IFlightService
    {
        private readonly IFlightsRepository repository;

        public FlightService(IFlightsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CabinDto> GetCabinForFlight(int flightId)
        {
            DomainModel.Entities.Flight flight = await this.repository.FindByIdAsync(flightId);
            ICollection<int> bookedSeats = flight.Tickets.Select(x => x.Seat).ToList();
            int seatsPerRow = flight.Aircraft.Capacity / flight.Aircraft.Row;

            var cabin = new CabinDto
            {
                RowsCount = flight.Aircraft.Row,
                BoookedSeats = bookedSeats,
                SeatsPerRow = seatsPerRow
            };

            return cabin;
        }

        public List<int> GetAvailableSeats(int number)
        {
            // TODO implement real generation of free seats list
            var seats = new List<int>();
            for (var i = 1; i < number + 1; i++)
            {
                seats.Add(i);
            }
            return seats;
        }
    }
}
