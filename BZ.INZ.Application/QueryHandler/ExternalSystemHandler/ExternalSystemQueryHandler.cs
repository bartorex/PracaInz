using System.Linq;
using System.Threading.Tasks;
using BZ.INZ.Application.Core.Query;
using BZ.INZ.Integration.Core.Gateway;
using BZ.INZ.Integration.SomeExternalSystem.Gateway.Request;
using BZ.INZ.Integration.SomeExternalSystem.Gateway.Response;

namespace BZ.INZ.Application.QueryHandler.ExternalSystemHandler {
    public class ExternalSystemQueryHandler : IQueryHandlerAsync<ExternalDataRequest,ExternalDataResponse> {
        private readonly IGateway<ExternalDataRequest, ExternalDataResponse> externalGateway;

        public ExternalSystemQueryHandler(IGateway<ExternalDataRequest, ExternalDataResponse> externalGateway) {
            this.externalGateway = externalGateway;
        }

        public async Task<IQueryable<ExternalDataResponse>> QueryAsync(ExternalDataRequest request) {
            var response = await externalGateway.CallAsync(request);
            return new ExternalDataResponse[] { response }.AsQueryable();
        }
    }
}
