using System;
using System.Collections.Generic;

namespace EasyFlights.DomainModel.Entities.Comparers
{
    public class CitiesComparer : IEqualityComparer<City>
    {
        public bool Equals(City x, City y)
        {
            return StringComparer.InvariantCultureIgnoreCase.Equals(x.Name, y.Name);
        }

        public int GetHashCode(City obj)
        {
            return StringComparer.InvariantCultureIgnoreCase.GetHashCode(obj.Name);
        }
    }
}
