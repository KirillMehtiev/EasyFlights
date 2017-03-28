using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.Data.Repositories.Cities;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Services.Common;
using EasyFlights.Services.Interfaces;

namespace EasyFlights.Services.Services.Typeahead
{
    public class TypeaheadService : ITypeaheadProvider<City>
    {
        private const int MaxNumber = 10;
        private readonly ICitiesRepository repository;

        public TypeaheadService(ICitiesRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<City>> GetTypeaheadAsync(string partialName)
        {
            Guard.ArgumentNotNullOrEmpty(partialName, nameof(partialName));
            Guard.ArgumentInRange(partialName.Length > 1, "length must be > 1", nameof(partialName));
            partialName = partialName.ToUpperInvariant().FirstOrDefault() +
                          partialName.ToLowerInvariant().Substring(1);
            return await 
                repository.GetAll()
                    .Where(x => x.Name.StartsWith(partialName)
                                || x.Name.Contains(" " + partialName)
                                || x.Airports.Any(y => y.Title.StartsWith(partialName))
                                || x.Airports.Any(y => y.Title.Contains(" " + partialName))
                                || x.Airports.Any(y => y.AirportCodeIata.StartsWith(partialName))
                                || x.Airports.Any(y => y.AirportCodeIcao.StartsWith(partialName))
                                || x.Country.Name.StartsWith(partialName)
                                || x.Country.Name.Contains(" " + partialName))
                    .Take(MaxNumber)
                    .ToListAsync();
        }
    }
}
