namespace EasyFlights.Data.Autocomplete
{
    using System.Collections.Generic;

    public interface ITypeaheadProvider<T>
    {
        IEnumerable<T> GetTypeahead(string pattern);
    }
}
