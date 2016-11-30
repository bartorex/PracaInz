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
            var response = await unitOfWork.Add(command.JobOffer);
            return new CommandResult<Guid> { Value = response.Id };
        }
    }
}
