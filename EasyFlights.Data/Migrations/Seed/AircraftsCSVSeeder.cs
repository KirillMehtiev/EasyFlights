using System.Linq;
using EasyFlights.Data.DataContexts;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.Migrations.Seed
{
    public class AircraftsCsvSeeder
    {
        public const int ModelIndex = 0;
        public const int CapacityIndex = 1;

        public void Seed(IDataContext context)
        {
            if (context.Set<Aircraft>().Any())
            {
                return;
            }

        }
    }
}
