namespace EasyFlights.Data.Typeahead
{
    using System.Collections.Generic;

    public interface ITypeaheadProvider<T>
    {
        IEnumerable<T> GetTypeahead(string pattern);
    }
}
