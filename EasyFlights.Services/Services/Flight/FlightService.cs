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

        public async Task<List<int>> GetAvailableSeats(int number, int flightId, List<int> bookedTickets)
        {
            DomainModel.Entities.Flight flight = await repository.FindByIdAsync(flightId);
            var seats = new List<int>();
            if (flight.Tickets == null || flight.Tickets.Count == 0)
            {
                for (var i = 1; i < number + 1; i++)
                {
                    seats.Add(i);
                }
            }
            else
            {
                var blocked = new List<int>();
                foreach (Ticket ticket in flight.Tickets)
                {
                    blocked.Add(ticket.Seat);
                }

                if (bookedTickets != null)
                {
                    foreach (int seat in bookedTickets)
                    {
                        blocked.Add(seat);
                    }
                }

                for (var i = 1; i < flight.Aircraft.Capacity + 1; i++)
                {
                    if (!blocked.Contains(i))
                    {
                        seats.Add(i);
                        if (seats.Count == number)
                        {
                            break;
                        }
                    }
                    else
                    { 
                        seats.Clear();
                    }
                }
                if (seats.Count < number)
                {
                    for (var i = 1; i < flight.Aircraft.Capacity + 1; i++)
                    {
                        if (!seats.Contains(i) && !blocked.Contains(i))
                        {
                            seats.Add(i);
                            if (seats.Count == number)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return seats;
        }
    }
}
