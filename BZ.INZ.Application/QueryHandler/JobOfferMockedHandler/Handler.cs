using System;
using System.Linq;
using System.Threading.Tasks;
using BZ.INZ.Application.Core.Query;
using BZ.INZ.Domain.Model.Query.Detail;
using BZ.INZ.Application.Mocks;

namespace BZ.INZ.Application.QueryHandler.JobOfferMockedHandler {
    public class Handler : IQueryHandlerAsync<Key, JobOffer> {
        private readonly JobOffersMocks mockedDataProvider;

        public Handler(JobOffersMocks mockedDataProvider) {
            this.mockedDataProvider = mockedDataProvider;
        }

        public async Task<IQueryable<JobOffer>> QueryAsync(Key request) {
            return mockedDataProvider.MockedData.AsQueryable();
        }
    }
}
