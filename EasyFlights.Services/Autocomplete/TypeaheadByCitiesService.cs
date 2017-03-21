namespace EasyFlights.Services.Autocomplete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Data.Autocomplete;
    using Data.Repositories.Base;
    using DomainModel.Entities;

    public class TypeaheadByCitiesService : ITypeaheadProvider<City>
    {
        private readonly IRepository<City> repository;

        public TypeaheadByCitiesService(IRepository<City> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<City> GetTypeahead(string pattern)
        {
            if (pattern.Contains('\\'))
            {
                throw new ArgumentException("Pattern contains unacceptable characters");
            }
            pattern = pattern.ToUpperInvariant().FirstOrDefault() + pattern.ToLowerInvariant().Substring(1);
            var regex = new Regex(pattern + "\\w*");
            return this.repository.GetAll().Where(x => regex.IsMatch(x.Name));
        }
    }
}
