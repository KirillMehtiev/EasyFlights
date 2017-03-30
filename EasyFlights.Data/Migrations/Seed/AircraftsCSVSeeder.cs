using System;
using System.Linq;
using EasyFlights.Data.DataContexts;
using EasyFlights.Data.Properties;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.Migrations.Seed
{
    public class AircraftsCsvSeeder
    {
        public const int Id = 0;
        public const int ModelIndex = 1;
        public const int CapacityIndex = 2;
        public const int RowIndex = 3;

        public void Seed(IDataContext context)
        {
            if (context.Set<Aircraft>().Any())
            {
                return;
            }
            string[] aircraftsInfo = Resources.aircrafts.Split('\n');
            context.AutoDetectChangesEnabled = false;
            try
            {
                for (var i = 1; i < aircraftsInfo.Length; i++)
                {
                    string[] info = aircraftsInfo[i].Split(';');
                    if (info.Length < CapacityIndex + 1)
                    {
                        continue;
                    }                    
                    Aircraft aircraft;                 
                    aircraft = new Aircraft { Model = info[ModelIndex], Capacity = int.Parse(info[CapacityIndex]), Row = int.Parse(info[RowIndex]) };
                    context.Set<Aircraft>().Add(aircraft);
                }
            }
            finally
            {
                context.AutoDetectChangesEnabled = true;
                context.DetectChanges();
            }
            context.SaveChanges();
        }
    }
}
