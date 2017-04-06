using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyFlights.Data.DataContexts;
using EasyFlights.Data.Repositories.Base;
using EasyFlights.Data.Repositories.Flights;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.Repositories.Flights
{
    /// <summary>
    /// Repository for flights
    /// </summary>
    public class FlightsRepository : Repository<Flight>, IFlightsRepository
    {
        public FlightsRepository(IDataContext dataContext)
            : base(dataContext)
        {
        }

        public IEnumerable<Flight> GetFlightsByDeparture(Airport departureAirport, DateTime departureTime)
        {
            IQueryable<Flight> result =
                this.GetAll()
                    .Where(flight => flight.DepartureAirport.Id == departureAirport.Id
                            && flight.ScheduledDepartureTime.Date == departureTime.Date);

            return result.ToList();
        }

        public async Task<Flight> GetFlightsById(int flightId)
        {
            return await this.FindByIdAsync(flightId);
        }
    }
}

