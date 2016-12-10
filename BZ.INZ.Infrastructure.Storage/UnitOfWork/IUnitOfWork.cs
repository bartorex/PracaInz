using System.Linq;
using System.Threading.Tasks;

namespace BZ.INZ.Infrastructure.Storage.UnitOfWork {
    public interface IUnitOfWork {
        Task<IQueryable<T>> Query<T>() where T : class;
        Task<T> Add<T>(T entity) where T : class;
        Task Delete<T>(T entity) where T : class;
        Task Update<T>(T entity) where T : class;
        Task SaveChangesAsync();
    }
}
