using System.Linq;

namespace EasyFlights.Data.Repositories.Base
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        void Add(T entity);

        void Delete(T entity);

        void SaveChanges();
    }
}
