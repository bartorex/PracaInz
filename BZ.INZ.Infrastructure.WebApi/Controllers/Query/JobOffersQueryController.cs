﻿using BZ.INZ.Application.Core.Query;
using BZ.INZ.Application.QueryHandler.JobOfferHandler;
using BZ.INZ.Application.QueryHandler.JobOfferMockedHandler;
using BZ.INZ.Domain.Model.Query.Detail;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace BZ.INZ.Infrastructure.WebApi.Controllers.Query {
    [RoutePrefix("jobOffersQuery")]
    public class JobOffersQueryController : ApiController {
        private readonly IQueryHandlerAsync<MockedJobOfferKey, JobOffer> mockedJobOfferHandler;
        private readonly IQueryHandlerAsync<JobOfferKey, JobOffer> jobOffesQueryHandler;
        public JobOffersQueryController(
            IQueryHandlerAsync<MockedJobOfferKey, JobOffer> mockedJobOfferHandler,
            IQueryHandlerAsync<JobOfferKey, JobOffer> jobOffesQueryHandler) {
            this.mockedJobOfferHandler = mockedJobOfferHandler;
            this.jobOffesQueryHandler = jobOffesQueryHandler;
        }

        [HttpGet]
        [Route("getOffers")]
        public async Task<IEnumerable<JobOffer>> JobOffers() {
            return await jobOffesQueryHandler.QueryAsync(new JobOfferKey());
        }
    }
}