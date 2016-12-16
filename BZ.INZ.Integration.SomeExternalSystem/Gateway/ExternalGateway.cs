using BZ.INZ.Integration.Core.Gateway;
using BZ.INZ.Integration.SomeExternalSystem.Gateway.Request;
using BZ.INZ.Integration.SomeExternalSystem.Gateway.Response;
using System;
using System.Threading.Tasks;

namespace BZ.INZ.Integration.SomeExternalSystem.Gateway {
    public class ExternalGateway : IGateway<ExternalDataRequest, ExternalDataResponse> {
        private readonly Client.Client client;

        public ExternalGateway(Client.Client client) {
            this.client = client;
        }

        public async Task<ExternalDataResponse> CallAsync(ExternalDataRequest request) {
            client.Connect();
            var response = client.GetData(request);
            return await Task.Run(() => {
                return response;
            });
        }
    }
}
