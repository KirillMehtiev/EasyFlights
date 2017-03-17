using System;
using System.Data.Entity;

namespace EasyFlights.Data.DataContexts
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();

        DbSet<T> Set<T>() where T : class;
    }
}
