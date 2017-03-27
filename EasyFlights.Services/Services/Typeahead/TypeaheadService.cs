using System;
using System.Collections.Generic;
using System.Linq;
using EasyFlights.Data.Repositories.Cities;
using EasyFlights.DomainModel.Entities;
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

        public List<City> GetTypeahead(string partialName)
        {
            if (partialName.Length <= 1)
            {
                return new List<City>();
            }
            if (partialName.Contains('\\'))
            {
                throw new ArgumentException(nameof(partialName) + " contains unacceptable characters");
            }
            partialName = partialName.ToUpperInvariant().FirstOrDefault() +
                          partialName.ToLowerInvariant().Substring(1);
            return
                repository.GetAll()
                    .Where(x => x.Name.StartsWith(partialName) || x.Airports.Any(y => y.Title.StartsWith(partialName))).Take(10)
                    .ToList();
        }
    }
}
