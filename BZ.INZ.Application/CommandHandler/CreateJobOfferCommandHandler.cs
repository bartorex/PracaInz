using BZ.INZ.Application.Command.SampleCommand;
using BZ.INZ.Application.Core.Command;
using BZ.INZ.Infrastructure.Storage.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace BZ.INZ.Application.CommandHandler {
    public class CreateJobOfferCommandHandler : ICommandHandler<CreateJobOfferCommand, Guid> {
        private readonly IUnitOfWork unitOfWork;

        public CreateJobOfferCommandHandler(IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CommandResult<Guid>> Handle(CreateJobOfferCommand command) {
            command.JobOffer.Id = Guid.NewGuid();
            command.JobOffer.DateRequested = DateTime.Now;
            var response = await unitOfWork.Add(command.JobOffer);
            await unitOfWork.SaveChangesAsync();
            return new CommandResult<Guid> { Value = response.Id };
        }
    }
}
