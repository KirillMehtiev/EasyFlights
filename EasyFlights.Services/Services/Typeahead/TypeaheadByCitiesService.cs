using EasyFlights.Data.Typeahead;

namespace EasyFlights.Services.Services.Typeahead
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Data.Repositories.Base;
    using DomainModel.Entities;

    public class TypeaheadByCitiesService : ITypeaheadProvider<City>
    {
        private readonly IRepository<City> repository;

        public TypeaheadByCitiesService(IRepository<City> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<City> GetTypeahead(string partialName)
        {
            if (partialName.Contains('\\'))
            {
                throw new ArgumentException("Pattern contains unacceptable characters");
            }
            partialName = partialName.ToUpperInvariant().FirstOrDefault() + partialName.ToLowerInvariant().Substring(1);
            var regex = new Regex(partialName + "\\w*");
            return this.repository.GetAll().Where(x => regex.IsMatch(x.Name));
        }
    }
}
