using EasyFlights.Data.DataContexts;
using System.Linq;

namespace EasyFlights.Data.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IDataContext _dataContext;

        public Repository(IDataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public void Add(T entity)
        {
            this._dataContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this._dataContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return this._dataContext.Set<T>().AsQueryable();
        }

        public void SaveChanges()
        {
            this._dataContext.SaveChanges();
        }
    }
}
