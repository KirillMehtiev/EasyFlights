using System.Collections.Generic;
using System.Threading.Tasks;
using EasyFlights.DomainModel.DTOs;

namespace EasyFlights.Services.Interfaces
{
    public interface IFlightService
    {
        Task<CabinDto> GetCabinForFlight(int flightId);

        List<int> GetAvailableSeats(int number);
    }
}
