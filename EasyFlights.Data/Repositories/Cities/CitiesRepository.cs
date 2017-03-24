using EasyFlights.Data.DataContexts;
using EasyFlights.Data.Repositories.Base;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.Repositories.Cities
{
    public class CitiesRepository : Repository<City>, ICitiesRepository
    {
        public CitiesRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
