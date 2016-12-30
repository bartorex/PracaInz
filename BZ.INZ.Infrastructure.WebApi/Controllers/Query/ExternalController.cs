using BZ.INZ.Application.Core.Query;
using BZ.INZ.Integration.SomeExternalSystem.Gateway.Request;
using BZ.INZ.Integration.SomeExternalSystem.Gateway.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace BZ.INZ.Infrastructure.WebApi.Controllers.Query {
    [RoutePrefix("external")]
    public class ExternalController : ApiController {
        private readonly IQueryHandlerAsync<ExternalDataRequest, ExternalDataResponse> handler;

        public ExternalController(
          IQueryHandlerAsync<ExternalDataRequest, ExternalDataResponse> handler) {
            this.handler = handler;
        }

        [HttpGet]
        [Route("getData")]
        public async Task<IEnumerable<ExternalDataResponse>> GetExternalData() {
            return await handler.QueryAsync(new ExternalDataRequest { Data = "TestValue" });
        }
    }
}
