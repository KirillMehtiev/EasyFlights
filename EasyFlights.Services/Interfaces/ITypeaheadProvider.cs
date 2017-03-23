using System.Collections.Generic;

namespace EasyFlights.Services.Interfaces
{
    public interface ITypeaheadProvider<TEntity>
    {
        List<TEntity> GetTypeahead(string partialName);
    }
}
