using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyFlights.Services.Interfaces
{
    public interface ITypeaheadProvider<TEntity>
    {
        Task<List<TEntity>> GetTypeaheadAsync(string partialName);
        List<TEntity> GetTypeahead(string partialName);
    }

}
