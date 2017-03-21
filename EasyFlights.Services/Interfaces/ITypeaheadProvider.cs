namespace EasyFlights.Services.Interfaces
{
    using System.Collections.Generic;

    public interface ITypeaheadProvider<TEntity>
    {
        List<TEntity> GetTypeahead(string partialName);
    }
}
