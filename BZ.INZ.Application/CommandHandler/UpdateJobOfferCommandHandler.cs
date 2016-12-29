using BZ.INZ.Application.Command;
using BZ.INZ.Application.Core.Command;
using BZ.INZ.Domain.Model.Query.Detail;
using BZ.INZ.Infrastructure.Storage.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.INZ.Application.CommandHandler {
    public class UpdateJobOfferCommandHandler : ICommandHandler<UpdateJobOfferCommand, JobOffer> {
        private readonly IUnitOfWork unitOfWork;

        public UpdateJobOfferCommandHandler(IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CommandResult<JobOffer>> Handle(UpdateJobOfferCommand command) {
            await unitOfWork.Update(command.JobOffer);
            await unitOfWork.SaveChangesAsync();
            return new CommandResult<JobOffer> { Value = command.JobOffer }; 
        }
    }
}
