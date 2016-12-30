using BZ.INZ.Integration.Core.Gateway;
using BZ.INZ.Integration.SomeExternalSystem.Gateway.Request;
using BZ.INZ.Integration.SomeExternalSystem.Gateway.Response;
using System;
using System.Threading.Tasks;

namespace BZ.INZ.Integration.SomeExternalSystem.Gateway {
    public class ExternalGateway : IGateway<ExternalDataRequest, ExternalDataResponse> {
        private readonly ExternalService.IHelloService helloService;

        public ExternalGateway() {
            helloService = new ExternalService.HelloServiceClient();
        }

        public async Task<ExternalDataResponse> CallAsync(ExternalDataRequest request) {
            return await Task.Run(() => {
                var response = helloService.ExtarnalSystemFunction(request.Data);
                return new ExternalDataResponse {
                    Data = response
                };
            });
        }
    }
}
