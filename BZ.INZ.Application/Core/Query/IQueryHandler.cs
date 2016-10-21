using System.Linq;
using System.Threading.Tasks;

namespace BZ.INZ.Application.Core.Query {
    public interface IQueryHandler<TRequest,TResponse>{
        IQueryable<TResponse> Query(TRequest request);
    }

    public interface IQueryHandlerAsync<TRequest, TResponse> {
        Task<IQueryable<TResponse>> Query(TRequest request);
    }
}
