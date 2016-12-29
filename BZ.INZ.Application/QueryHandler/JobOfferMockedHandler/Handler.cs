using System;
using System.Linq;
using System.Threading.Tasks;
using BZ.INZ.Application.Core.Query;
using BZ.INZ.Domain.Model.Query.Detail;
using BZ.INZ.Application.Mocks;
using BZ.INZ.Infrastructure.Storage.UnitOfWork;

namespace BZ.INZ.Application.QueryHandler.JobOfferMockedHandler {
    public class Handler : IQueryHandlerAsync<MockedJobOfferKey, JobOffer> {
        private readonly JobOffersMocks mockedDataProvider;
        private readonly IUnitOfWork unitOfWork;
         public Handler(JobOffersMocks mockedDataProvider, IUnitOfWork unitOfWork) {
            this.mockedDataProvider = mockedDataProvider;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IQueryable<JobOffer>> QueryAsync(MockedJobOfferKey request) {
            return mockedDataProvider.MockedData.AsQueryable();
        }
    }
}
