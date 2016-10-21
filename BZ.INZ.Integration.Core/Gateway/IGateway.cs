using System.Threading.Tasks;

namespace BZ.INZ.Integration.Core.Gateway {
    public interface IGateway<in TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse {
        Task<TResponse> CallAsync(TRequest request);
    }
}
