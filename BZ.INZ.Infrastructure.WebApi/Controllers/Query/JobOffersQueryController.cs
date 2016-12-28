using BZ.INZ.Application.Core.Query;
using BZ.INZ.Application.QueryHandler.JobOfferMockedHandler;
using BZ.INZ.Domain.Model.Query.Detail;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace BZ.INZ.Infrastructure.WebApi.Controllers.Query {
    [RoutePrefix("jobOffersQuery")]
    public class JobOffersQueryController : ApiController {
        private readonly IQueryHandlerAsync<Key, JobOffer> mockedJobOfferHandler;

        public JobOffersQueryController(IQueryHandlerAsync<Key, JobOffer> mockedJobOfferHandler) {
            this.mockedJobOfferHandler = mockedJobOfferHandler;
        }

        [HttpGet]
        [Route("getMockedOffers")]
        public async Task<IEnumerable<JobOffer>> JobOffers() {
            return await mockedJobOfferHandler.QueryAsync(new Key());
        }
    }
}