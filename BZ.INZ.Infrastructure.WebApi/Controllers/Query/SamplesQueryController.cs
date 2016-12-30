using BZ.INZ.Application.Core.Query;
using BZ.INZ.Integration.SomeExternalSystem.Gateway.Request;
using BZ.INZ.Integration.SomeExternalSystem.Gateway.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace BZ.INZ.Infrastructure.WebApi.Controllers.Query {
    [RoutePrefix("samplesQuery")]
    public class SamplesQueryController : ApiController {
        private readonly IQueryHandlerAsync<string, string> testHandler;
        private readonly IQueryHandlerAsync<ExternalDataRequest, ExternalDataResponse> handler;

        public SamplesQueryController(
            IQueryHandlerAsync<string,string> testHandler,
            IQueryHandlerAsync<ExternalDataRequest, ExternalDataResponse> handler) {
            this.testHandler = testHandler;
            this.handler = handler;
        }

        //[HttpGet]
        //[Route("getTest")]
        //public async Task<IEnumerable<string>> GetTest() {
        //    var result =  await testHandler.QueryAsync("TEST");
        //    return result;
        //}

        [HttpGet]
        [Route("getTest")]
        public async Task<IEnumerable<ExternalDataResponse>> GetExternalData() {
            return await handler.QueryAsync(new ExternalDataRequest { Data = "TestValue" });
        }
    }
}