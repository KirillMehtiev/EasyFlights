using System;
using System.Collections.Generic;
using System.Linq;
using EasyFlights.Data.Repositories.Base;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Services.Interfaces;

namespace EasyFlights.Services.Services.Typeahead
{
    public class TypeaheadByCitiesService : ITypeaheadProvider<City>
    {
        private readonly IRepository<City> repository;

        public TypeaheadByCitiesService(IRepository<City> repository)
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
            return repository.GetAll().Where(x => x.Name.StartsWith(partialName)).ToList();
        }
    }
}
