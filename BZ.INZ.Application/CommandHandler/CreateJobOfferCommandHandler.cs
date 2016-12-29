using BZ.INZ.Application.Command.SampleCommand;
using BZ.INZ.Application.Core.Command;
using BZ.INZ.Domain.Model.Query.Detail;
using BZ.INZ.Infrastructure.Storage.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace BZ.INZ.Application.CommandHandler {
    public class CreateJobOfferCommandHandler : ICommandHandler<CreateJobOfferCommand, JobOffer> {
        private readonly IUnitOfWork unitOfWork;

        public CreateJobOfferCommandHandler(IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CommandResult<JobOffer>> Handle(CreateJobOfferCommand command) {
            command.JobOffer.Id = Guid.NewGuid();
            command.JobOffer.DateRequested = DateTime.Now;
            var response = await unitOfWork.Add(command.JobOffer);
            await unitOfWork.SaveChangesAsync();
            return new CommandResult<JobOffer> { Value = response };
        }
    }
}
