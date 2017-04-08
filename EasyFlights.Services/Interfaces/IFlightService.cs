using System.Collections.Generic;
using System.Threading.Tasks;
using EasyFlights.DomainModel.DTOs;

namespace EasyFlights.Services.Interfaces
{
    public interface IFlightService
    {
        Task<CabinDto> GetCabinForFlight(int flightId);

        Task<List<int>> GetAvailableSeats(int number, int flightId, List<int> bookedTickets);
    }
}
