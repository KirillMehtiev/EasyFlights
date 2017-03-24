using System.Linq;
using System.Threading.Tasks;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.Repositories.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();

        Task<T> FindByIdAsync(int id);

        void Add(T entity);

        void Delete(T entity);

        void SaveChanges();
    }
}
