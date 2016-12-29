using System.Linq;
using System.Threading.Tasks;
using BZ.INZ.Application.Core.Query;
using BZ.INZ.Domain.Model.Query.Detail;
using BZ.INZ.Infrastructure.Storage.UnitOfWork;

namespace BZ.INZ.Application.QueryHandler.JobOfferHandler {
    public class Handler : IQueryHandlerAsync<JobOfferKey,JobOffer> {
        private readonly IUnitOfWork unitOfWork;

        public Handler(IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IQueryable<JobOffer>> QueryAsync(JobOfferKey request) {
            return await unitOfWork.Query<JobOffer>();
        }
    }
}
