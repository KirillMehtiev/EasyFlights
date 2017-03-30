using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.Data.Repositories.Flights;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;
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
            List<Ticket> bookedTickets = flight.Tickets.ToList();

            var seats = new List<SeatDto>();
            for (var i = 1; i <= flight.Aircraft.Capacity; i++)
            {
                bool isBooked = bookedTickets.Exists(x => x.Seat == i);
                var seat = new SeatDto
                {
                    Number = i,
                    IsBooked = isBooked
                };

                seats.Add(seat);
            }

            var cabin = new CabinDto
            {
                RowCount = flight.Aircraft.Row,
                Seats = seats
            };

            return cabin;
        }
    }
}
