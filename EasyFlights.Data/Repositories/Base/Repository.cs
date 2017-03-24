using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.Data.DataContexts;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private IDataContext dataContext;

        public Repository(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Add(T entity)
        {
            this.dataContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.dataContext.Set<T>().Remove(entity);
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await this.GetAll().FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return this.dataContext.Set<T>().AsQueryable();
        }

        public void SaveChanges()
        {
            this.dataContext.SaveChanges();
        }
    }
}
