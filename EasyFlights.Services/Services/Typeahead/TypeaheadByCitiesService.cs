using System;
using System.Collections.Generic;
using System.Linq;
using EasyFlights.Data.Repositories.Base;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Services.Interfaces;

namespace EasyFlights.Services.Services.Typeahead
{
    public class TypeaheadByCitiesService : ITypeaheadProvider<CityDto>
    {
        private readonly IRepository<City> repository;

        public TypeaheadByCitiesService(IRepository<City> repository)
        {
            this.repository = repository;
        }

        public List<CityDto> GetTypeahead(string partialName)
        {
            if (partialName.Length > 1)
            {
                if (partialName.Contains('\\'))
                {
                    throw new ArgumentException(nameof(partialName) + " contains unacceptable characters");
                }
                partialName = partialName.ToUpperInvariant().FirstOrDefault() +
                              partialName.ToLowerInvariant().Substring(1);
                List<City> cities = repository.GetAll().Where(x => x.Name.StartsWith(partialName)).ToList();
                var result = new List<CityDto>();
                cities.ForEach(x => result.Add(new CityDto() { Name = x?.Name, Country = x?.Country?.Name }));
                return result;
            }
            return new List<CityDto>();
        }
    }
}
