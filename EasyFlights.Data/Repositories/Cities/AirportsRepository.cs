﻿using EasyFlights.Data.DataContexts;
using EasyFlights.Data.Repositories.Base;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.Repositories.Cities
{
    public class AirportsRepository : Repository<Airport>, IAirportsRepository
    {
        public AirportsRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
